
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Myriadbits.MXF
{
	public class MXFPatchIndexCloseFirstGOP : MXFValidator
	{
		private List<MXFIndexTableSegment> m_indexTables = new List<MXFIndexTableSegment>();

		private class Patch
		{
			public long position;
			public byte oldvalue;
			public byte newvalue;
			public Patch(long p, byte oldv, byte newv)
			{
				position = p;
				oldvalue = oldv;
				newvalue = newv;
			}
		}

		/// <summary>
		/// Check all index tables
		/// </summary>
		/// <param name="file"></param>
		/// <param name="results"></param>
		public override void OnExecuteTest(ref List<MXFValidationResult> results)
		{
			MXFValidationResult valResult = new MXFValidationResult("Patch index : close first GOP");
			results.Add(valResult); // And directly add the results
			
			// Clear list
			m_indexTables = new List<MXFIndexTableSegment>();

			if ((this.File.Partitions == null) || (this.File.Partitions.Count < 1))
			{
				valResult.SetError("No partition found!");
				return;
			}

			// Find index tables in header, first and second body and footer partitions
			if (this.File.Partitions.Count >= 1)
			    FindIndexTableAndSystemItems(this.File.Partitions[0]);
			if (this.File.Partitions.Count >= 2)
				FindIndexTableAndSystemItems(this.File.Partitions[1]);
			if (this.File.Partitions.Count >= 3)
				FindIndexTableAndSystemItems(this.File.Partitions[2]);
			if (this.File.Partitions.Count >= 4)
				FindIndexTableAndSystemItems(this.File.Partitions[this.File.Partitions.Count-1]);
			if (this.m_indexTables.Count == 0)
			{
				valResult.SetError(string.Format("No index tables found!", m_indexTables.Count));
				return;
			}

			// Build patch list
			List<Patch> PatchList = new List<Patch>();
			foreach (MXFIndexTableSegment tablestart in this.m_indexTables.Where(a => a.IndexStartPosition == 0))
			{
				if ((tablestart.IndexEntries.Count > 2)
					&& ((tablestart.IndexEntries[0].Flags & (0x80 + 0x40)) == 0x80 + 0x40)  // Index 0 : Random Access + Sequence Header
					&& ((tablestart.IndexEntries[1].Flags & 0x20) == 0x20)                  // Index 1 : Backward prediction
					)
				{
					for (int i=1; i<=2; i++)
					{
						if ((tablestart.IndexEntries[i].Flags & 0x20) == 0x20)
						{
							byte newvalue = (byte)(tablestart.IndexEntries[i].Flags & ~0x20);
							PatchList.Add(new Patch(tablestart.IndexEntries[i].Offset + 2, (byte)tablestart.IndexEntries[i].Flags, newvalue));
						}
					}
				}
			}
			if (PatchList.Count == 0)
			{
				valResult.SetSuccess("Patch/Index/ClosedGOP : no need to patch");
				return;
			}
			
			// Actual patch
			using (FileStream PatchFile = new FileStream(this.File.Filename, FileMode.Open, FileAccess.ReadWrite))
			{
				foreach (Patch patch in PatchList)
				{
					PatchFile.Position = patch.position;
					if (PatchFile.ReadByte() != patch.oldvalue)
					{
						valResult.SetError("Patch/Index/ClosedGOP : failed, internal error : unexpected reading");
						return;
					}

					PatchFile.Position = patch.position;
					PatchFile.WriteByte(patch.newvalue);
				}
			}
			valResult.SetSuccess(string.Format("Patch/Index/ClosedGOP : success : {0} patches applied", PatchList.Count));
		}

		/// <summary>
		/// Locate all index table segments RECURSIVELY
		/// </summary>
		/// <param name="current"></param>
		public void FindIndexTableAndSystemItems(MXFObject current)
		{
			// LOAD the object (when not yet loaded)
			// This may take some time!!!
			current.Load();

			MXFKLV klv = current as MXFKLV;
			if (klv != null)
			{
				if (klv.Key.Type == KeyType.IndexSegment)
				{
					MXFIndexTableSegment its = klv as MXFIndexTableSegment;
					if (its != null)
						this.m_indexTables.Add(its);
				}
			}

			if (current.Children == null)
				return;

			foreach(MXFObject child in current.Children)
			{
				FindIndexTableAndSystemItems(child);
			}
		}

	}
}
