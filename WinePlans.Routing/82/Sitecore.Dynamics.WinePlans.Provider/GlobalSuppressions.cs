// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChangedProductsStepProcessor.#GetImageIdFromUrl(System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChangedProductsStepProcessor.#GetImageIdFromUrl(System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChangedProductsStepProcessor.#GetVariantTranslatedProperties(DataExchange.Commerce.Models.CommerceProduct,Microsoft.Dynamics.Commerce.Runtime.DataModel.ProductVariant,DataExchange.Commerce.Models.CommerceProductVariant,Sitecore.DataExchange.Contexts.pipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChangedProductsStepProcessor")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.BaseExtractCategoriesStepProcessor.#Process(Sitecore.DataExchange.Models.PipelineStep,Sitecore.DataExchange.Contexts.pipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractCatalogsStepProcessor.#Process(Sitecore.DataExchange.Models.PipelineStep,Sitecore.DataExchange.Contexts.PipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "DataExchange.Providers.DynamicsRetail.Plugins.Contexts.DynamicsPipelineContext.#ChannelAttributes")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "DataExchange.Providers.DynamicsRetail.Plugins.Contexts.DynamicsPipelineContext.#Categories")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", 
        Target = "DataExchange.Providers.DynamicsRetail.Plugins.Contexts.DynamicsPipelineContext.#Catalogs")]
[assembly: SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.Endpoints.DynamicsEndpointItemModel")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChannelProductAttributesStepProcessor.#Process(Sitecore.DataExchange.Models.PipelineStep,Sitecore.DataExchange.Contexts.PipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.PipelineSteps.ChooseRenderTemplateStepItemModel")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Scope = "member", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.TemplateContext.#Entities")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.PipelineSteps.ChooseRenderTemplateStepItemModel")]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.ExtractChangedProductsStepProcessor.#GetVariantTranslatedProperties(DataExchange.Commerce.Models.CommerceProduct,Microsoft.Dynamics.Commerce.Runtime.DataModel.ProductVariant,DataExchange.Commerce.Models.CommerceProductVariant,Sitecore.DataExchange.Contexts.PipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Processors.PipelineSteps.BaseExtractCategoriesStepProcessor.#Process(Sitecore.DataExchange.Models.PipelineStep,Sitecore.DataExchange.Contexts.PipelineContext)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.PipelineSteps.UpdateChannelHistoryStepItemModel")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", 
        Target = "DataExchange.Providers.DynamicsRetail.Models.PipelineSteps.MapImagesStepItemModel")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Scope = "member", 
        Target =
            "DataExchange.Providers.DynamicsRetail.Plugins.Managers.DynamicsCrtManager.#.ctor(DataExchange.Commerce.Plugins.DatabaseSettings,System.String)"
        )]

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.