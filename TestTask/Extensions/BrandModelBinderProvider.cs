using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Models.Requests;

namespace TestTask.JsonConverters
{
    public class BrandModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(CreateBrandBaseRequest))
            {
                return null;
            }

            var subclasses = new[] { typeof(CreateMrGreenBrandRequest), typeof(CreateRedBetBrandRequest), };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new DeviceModelBinder(binders);
        }
    }

    public class DeviceModelBinder : IModelBinder
    {
        private Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

        public DeviceModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            this.binders = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelFirstName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(CreateBrandBaseRequest.BrandType));
            var modelTypeValue = bindingContext.ValueProvider.GetValue(modelFirstName).FirstValue;

            IModelBinder modelBinder;
            ModelMetadata modelMetadata;
            Enum.TryParse(modelTypeValue, out BrandType brandType);
            if (brandType == BrandType.MrGreen)
            {
                (modelMetadata, modelBinder) = binders[typeof(CreateMrGreenBrandRequest)];
            }
            else if (brandType == BrandType.RedBet)
            {
                (modelMetadata, modelBinder) = binders[typeof(CreateRedBetBrandRequest)];
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                bindingContext.ActionContext,
                bindingContext.ValueProvider,
                modelMetadata,
                bindingInfo: null,
                bindingContext.ModelName);

            await modelBinder.BindModelAsync(newBindingContext);
            bindingContext.Result = newBindingContext.Result;

            if (newBindingContext.Result.IsModelSet)
            {
                // Setting the ValidationState ensures properties on derived types are correctly 
                bindingContext.ValidationState[newBindingContext.Result.Model] = new ValidationStateEntry
                {
                    Metadata = modelMetadata,
                };
            }
        }

    }
}