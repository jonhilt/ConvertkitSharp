using Machine.Specifications;
using ConvertKitSharp.Services;
using ConvertKitSharp.Entities;
using System.Collections.Generic;

namespace ConvertKitSharp.Tests.Forms
{
    [Subject(typeof(ConvertKitFormService))]
    class When_listing_forms
    {
        Establish context = () =>
        {
            Service = new ConvertKitFormService(Utils.ApiKey);
        };

        Because of = () =>
        {
            Result = Service.ListAsync().Await().AsTask.Result;
        };

        It should_list_forms = () =>
        {
            Result.ShouldNotBeNull();
        };

        Cleanup after = () =>
        {

        };

        static ConvertKitFormService Service;

        static IEnumerable<ConvertKitForm> Result;
    }
}
