## Scope
This document shows the SMPTE groups register as a hierarchical inheritance tree (as of September, 2020) 

## Group Registers Tree

| Mark          | Description                                       |
| ------------- | ------------------------------------------------- |
| :hammer:      | not fully implemented                             |
| :interrobang: | more investigation required to remove uncertainty |
| :question:    | unclear about what  this  group shouldrepresent   |
| :scroll:      | properties defined by local tags                  |
| :dart:        | easy to implement                                 |





<font size="-1">

- [ ] DMCVTGenericSet1 [12] *(abstract)* :question:
    - [ ] DMCVTApp1Set 
    - [ ] DMCVTApp2Set 
    - [ ] DMCVTApp3Set 
    - [ ] DMCVTApp4Set
- [x] InterchangeObject [(3+1)/4] *(abstract)* :hammer: :scroll:
    - [x] Component [5/5]*(abstract)* (= Structural Component):hammer: :scroll:
        - [x] Segment [0/0] *(abstract)*
            - [x] EdgeCode [4/4]
            - [x] EssenceGroup [2/2]
            - [x] Event [2/2]
                - [x] GPITrigger [1/1]
                - [x] CommentMarker [1/1]
                    - [x] DescriptiveMarker [5/5]
                      - [ ] DynamicMarker
                        - [ ] DynamicClip
            - [x] Filler [0/0] *(is this the B11 MXFFiller.cs?)* :question:
            - [ ] OperationGroup 
            - [ ] NestedScope 
            - [ ] Pulldown
            - [ ] ScopeReference 
            - [ ] Selector
            - [x] Sequence [1/1]
            - [ ] SourceReference [4] *(abstract)*
                - [x] SourceClip [3/5] :hammer: :scroll:
                    - [x] DescriptiveClip [1/1]
                - [ ] TextClip [0] *(abstract)*
                    - [ ] HTMLClip :scroll: :dart:
            - [x] Timecode [3/3]
            - [ ] TimecodeStream [3] *(abstract)* :scroll: :dart:
                - [ ] TimecodeStream12M :scroll: :dart:
            - [ ] Transition :scroll:
    - [x] ContentStorage [2/2] :scroll: :hammer:
    - [ ] ControlPoint :scroll:
    - [ ] DefinitionObject [3] *(abstract)* :scroll:
        - [ ] DataDefinition :scroll:
        - [ ] OperationDefinition :scroll:
        - [ ] ParameterDefinition :scroll:
        - [ ] PluginDefinition :scroll:
        - [ ] CodecDefinition :scroll:
        - [ ] ContainerDefinition :scroll:
        - [ ] InterpolationDefinition :scroll:
        - [ ] TaggedValueDefinition :scroll:
        - [ ] KLVDataDefinition :scroll:
        - [ ] OPDefinition :scroll:
        - [ ] CompressionDefinition :scroll:
    - [ ] Dictionary :scroll:
    - [ ] EssenceData [3/9] *(A05 EssenceContainerData)* :hammer: :scroll:
    - [x] EssenceDescriptor [1/2] *(abstract)* *(B02 GenericDescriptor)* :hammer: :scroll:
        - [x] FileDescriptor [5/5] *(abstract)*
            - [ ] AIFCDescriptor :scroll: :dart:
            - [x] PictureDescriptor [27/35] *(abstract)*:scroll: :hammer:
                - [x] CDCIDescriptor [10/10]
                    - [x] MPEGVideoDescriptor [10/10]
                    - [ ] VC1VideoDescriptor
                - [X] RGBADescriptor [8/8] :scroll: :hammer: :dart:
                - [ ] TIFFPictureEssenceDescriptor :scroll: :dart:
            - [ ] HTMLDescriptor *(abstract class?)*
            - [ ] TIFFDescriptor *(abstract class?)*
            - [ ] WAVEDescriptor *(abstract class?)*
            - [x] SoundDescriptor [8/10] :hammer: :scroll:
                - [x] WAVEPCMDescriptor [13/13] *(=MXFWAVEAudioEssenceDescriptor.cs)*
                    - [x] AES3PCMDescriptor [7/7]
                - [ ] DCPCMSoundDescriptor
                - [ ] MPEGAudioDescriptor
            - [x] DataEssenceDescriptor [1/1] :hammer:
                - [ ] ParsedTextDescriptor [1] *(abstract)*:scroll: :dart:
                    - [ ] SGMLDescriptor [0] *(abstract)*
                        - [ ] XMLDescriptor :scroll: :dart:
                        - [ ] HTMLParsedTextDescriptor :scroll: :dart:
                - [ ] RP217Descriptor :scroll: :dart:
                - [ ] VBIDataDescriptor
                - [ ] ANCDataDescriptor
                - [x] DCTimedTextDescriptor [0/4] :hammer:
                - [ ] EventTextDescriptor [2] *(abstract)*
                    - [ ] STLDescriptor
                - [ ] AuxDataEssenceDescriptor
            - [X] MultipleDescriptor [1/1]
            - [ ] DateTimeDescriptor :scroll: :dart:
        - [ ] FilmDescriptor :scroll: :dart:
        - [ ] TapeDescriptor :scroll:
        - [ ] PhysicalDescriptor [0] *(abstract)*
            - [ ] ImportDescriptor *(abstract class?)*
                - [ ] BWFImportDescriptor :scroll:
            - [ ] RecordingDescriptor *(abstract class?)*
            - [ ] AuxiliaryDescriptor :scroll: :dart: 
    - [X] Preface :hammer:
    - [x] Identification [9/9]
    - [ ] Locator [0] *(abstract)*
        - [x] NetworkLocator [1/1]
        - [x] TextLocator [1/1]
    - [x] Package [4/9] *(abstract)* :scroll: 
        - [ ] CompositionPackage [0/4] :hammer:
        - [x] MaterialPackage *abstract* [0/0]
        - [x] SourcePackage [1/1]
    - [ ] Track [4] *(abstract)*
        - [ ] EventTrack 
        - [ ] StaticTrack 
        - [ ] TimelineTrack 
    - [ ] Parameter [1] *(abstract)*
        - [ ] ConstantValue 
        - [ ] VaryingValue 
    - [ ] TaggedValue 
    - [ ] KLVData 
    - [ ] RIFFChunk 
    - [ ] SubDescriptor [0] *(abstract)*
        - [x] JPEG2000SubDescriptor [14/14]
        - [ ] StereoscopicPictureSubDescriptor
        - [ ] DCTimedTextResourceSubDescriptor
        - [x] ContainerConstraintsSubDescriptor [0/0]
        - [ ] MPEG4VisualSubDescriptor 
        - [x] MCALabelSubDescriptor [14/14]
            - [x] AudioChannelLabelSubDescriptor [0/1] *inheritance*
            - [x] SoundfieldGroupLabelSubDescriptor [0/1] *inheritance*
            - [x] GroupOfSoundfieldGroupsLabelSubDescriptor [0/0] *inheritance*
        - [x] AVCSubDescriptor [15/15]
        - [ ] STLSubDescriptor 
        - [ ] OperationsStereoscopicSubDescriptor
        - [ ] VC2SubDescriptor 
        - [ ] DMCVTTargetSubDescriptor 
        - [ ] VC5BayerPictureEssenceSubDescriptor
        - [ ] VC5CDCIPictureEssenceSubDescriptor
        - [ ] AACSubDescriptor 
        - [x] ACESPictureSubDescriptor [5/5]
        - [x] TargetFrameSubDescriptor [0/10] :hammer:
        - [ ] AS_07_TimecodeLabelSubdescriptor
    - [ ] PackageMarker 
    - [ ] ApplicationObject
        - [ ] ApplicationPlugInObject 
        - [ ] ApplicationReferencedObject 
    - [x] DescriptiveObject [1] *(abstract)*
        - [ ] DMS1Object [0] *(abstract)*
            - [ ] Publication 
            - [x] ContactsList [3/3]
            - [x] Address [15/15]
            - [ ] Communications 
            - [ ] PictureFormat 
            - [ ] NameValue 
            - [ ] Processing 
            - [ ] Project 
            - [ ] TextLanguage [0] *(abstract)*
                - [ ] Titles 
                - [ ] Branding
                - [ ] Shot 
                - [ ] CueWords
                - [x] Thesaurus [1/1] *(abstract)*
                    - [ ] DMS1Identification
                    - [ ] GroupRelationship
                    - [ ] DMS1Event
                    - [ ] Award
                    - [ ] CaptionsDescription
                    - [ ] DMS1Annotation
                    - [ ] SettingPeriod
                    - [ ] Scripting
                    - [ ] Classification
                    - [ ] Keypoint
                    - [ ] Participant
                    - [ ] Contract
                    - [ ] Rights
                    - [ ] DeviceParameters
                    - [x] Contact [3/3] *(abstract)*
                        - [ ] Person
                        - [ ] Organization
                        - [x] Location [2/2]
        - [ ] CryptographicContext 
        - [x] TextBasedObject [4/4]
            - [x] GenericStreamTextBasedSet [1/1]
                - [ ] AS_07_GSP_DMS_Object
            - [ ] UTF8TextBasedSet 
            - [ ] UTF16TextBasedSet 
        - [ ] AS_12_DescriptiveObject [0] *(abstract)*
            - [ ] DMS_AS_12_AdID_Slate
        - [ ] EBUCoreObject [0] *(abstract)*
            - [ ] coreMetadata 
            - [ ] metadataSchemaInformation
            - [ ] identifier 
            - [ ] title 
            - [ ] alternativeTitle 
            - [ ] subject 
            - [ ] description 
            - [ ] date 
            - [ ] dateType 
            - [ ] type 
            - [ ] objectType 
            - [ ] genre 
            - [ ] targetAudience 
            - [ ] language 
            - [ ] coverage 
            - [ ] spatial 
            - [ ] location 
            - [ ] coordinates 
            - [ ] temporal 
            - [ ] periodOfTime 
            - [ ] rights 
            - [ ] version 
            - [ ] rating 
            - [ ] publicationEvent 
            - [ ] publicationHistory 
            - [ ] publicationChannel 
            - [ ] publicationMedium 
            - [ ] publicationService 
            - [ ] entity 
            - [ ] contact 
            - [ ] organization 
            - [ ] department 
            - [ ] details 
            - [ ] address 
            - [ ] region 
            - [ ] compoundName 
            - [ ] role 
            - [ ] countryType 
            - [ ] customRelation 
            - [ ] basicRelation 
            - [ ] planning 
            - [ ] typeGroup 
            - [ ] formatGroup 
            - [ ] statusGroup 
            - [ ] textualAnnotation 
            - [ ] basicLink 
            - [ ] format 
            - [ ] videoFormat 
            - [ ] imageFormat 
            - [ ] audioFormat 
            - [ ] track 
            - [ ] dataFormat 
            - [ ] captioning 
            - [ ] subtitling 
            - [ ] ancillaryData 
            - [ ] signingFormat 
            - [ ] technicalAttributeString
            - [ ] technicalAttributeInt8
            - [ ] technicalAttributeInt16
            - [ ] technicalAttributeInt32
            - [ ] technicalAttributeInt64
            - [ ] technicalAttributeUInt8
            - [ ] technicalAttributeUInt16
            - [ ] technicalAttributeUInt32
            - [ ] technicalAttributeUInt64
            - [ ] technicalAttributeFloat
            - [ ] technicalAttributeRational
            - [ ] technicalAttributeAnyURI
            - [ ] technicalAttributeBoolean
            - [ ] dimension 
            - [ ] packageInfo 
            - [ ] medium 
            - [ ] codec 
            - [ ] rational 
            - [ ] aspectRatio 
            - [ ] height 
            - [ ] width 
            - [ ] part 
            - [ ] partMetadata 
            - [ ] hash 
            - [ ] locator
            - [ ] containerFormat 
            - [ ] audioFormatExtended
            - [ ] audioProgramme 
            - [ ] IDRef 
            - [ ] loudnessMetadata 
            - [ ] audioContent 
            - [ ] audioObject 
            - [ ] audioPackFormat 
            - [ ] audioChannelFormat 
            - [ ] audioBlockFormat 
            - [ ] audioBlockMatrixCoefficient
            - [ ] audioStreamFormat 
            - [ ] audioTrackFormat 
            - [ ] audioTrackUID 
            - [ ] audioMXFLookup 
            - [ ] audioBlockMatrix 
            - [ ] time 
            - [ ] metadataFormat 
            - [ ] timecodeFormat 
            - [ ] videoNoiseFilter 
            - [ ] audience 
            - [ ] filter 
            - [ ] filterSetting 
            - [ ] referenceScreen 
            - [ ] referenceScreenCentrePosition
            - [ ] referenceScreenWidth
            - [ ] audioContentDialogue
            - [ ] audioObjectInteraction
            - [ ] gainInteractionRange
            - [ ] positionInteractionRange
            - [ ] audioBlockPosition 
            - [ ] audioBlockDivergence
            - [ ] audioBlockZoneExclusion
            - [ ] audioBlockZone 
            - [ ] audioBlockJumpPosition
            - [ ] event 
            - [ ] award 
            - [ ] affiliation 
        - [ ] AS_07_DMS_Device 
        - [ ] AS_07_DMS_Identifier 
    - [x] DescriptiveFramework [1/1] *(abstract)*
        - [x] DMS1Framework [12/12] *(abstract)*
            - [ ] SceneFramework 
            - [x] ProductionClipFramework [4/4] *(abstract)*
                - [x] ProductionFramework [7/7]
                - [ ] ClipFramework
        - [ ] CryptographicFramework 
        - [ ] DMS_AS_03_Framework 
        - [x] TextBasedFramework
            - [ ] AS_07_GSP_DMS_Framework
                - [ ] AS_07_GSP_BD_DMS_Framework
                - [ ] AS_07_GSP_TD_DMS_Framework
        - [ ] EIDRFramework 
        - [ ] DM_Segmentation_Framework [0] *(abstract)*
            - [ ] DM_AS_11_Segmentation_Framework
            - [ ] AS_07_Segmentation_DMS_Framework 
        - [ ] DMS_AS_10_Core_Framework 
        - [ ] DM_AS_11_Core_Framework 
        - [ ] DMS_AS_12_Framework 
        - [ ] EBUCoreMainFramework 
        - [ ] APP_InfaxFramework 
        - [ ] APP_PSEAnalysisFramework 
        - [ ] APP_VTRReplayErrorFramework 
        - [ ] APP_DigiBetaDropoutFramework 
        - [ ] APP_TimecodeBreakFramework 
        - [ ] DM_AS_11_UKDPP_Framework 
        - [ ] AS_07_Core_DMS_Framework 
- [ ] MetaDefinition *(abstract)*
    - [ ] ClassDefinition 
    - [ ] PropertyDefinition
    - [ ] TypeDefinition [0] *(abstract)*
        - [ ] TypeDefinitionInteger 
        - [ ] TypeDefinitionStrongObjectReference
        - [ ] TypeDefinitionWeakObjectReference
        - [ ] TypeDefinitionEnumeration 
        - [ ] TypeDefinitionFixedArray 
        - [ ] TypeDefinitionVariableArray 
        - [ ] TypeDefinitionSet 
        - [ ] TypeDefinitionString 
        - [ ] TypeDefinitionStream 
        - [ ] TypeDefinitionRecord 
        - [ ] TypeDefinitionRename 
        - [ ] TypeDefinitionExtendibleEnumeration
        - [ ] TypeDefinitionIndirect
            - [ ] TypeDefinitionOpaque
        - [ ] TypeDefinitionCharacter
- [ ] PartitionPack [13] *(abstract)*
    - [ ] HeaderPartitionPack [0] *(abstract)*
        - [ ] HeaderPartitionOpenIncomplete 
        - [ ] HeaderPartitionClosedIncomplete
        - [ ] HeaderPartitionOpenComplete 
        - [ ] HeaderPartitionClosedComplete 
    - [ ] BodyPartitionPack [0]*(abstract)*
        - [ ] BodyPartitionOpenIncomplete 
        - [ ] BodyPartitionClosedIncomplete 
        - [ ] BodyPartitionOpenComplete 
        - [ ] BodyPartitionClosedComplete 
        - [ ] GenericStreamPartition 
    - [ ] FooterPartitionPack [0] *(abstract)*
        - [ ] FooterPartitionClosedIncomplete
        - [ ] FooterPartitionClosedComplete *
</font>