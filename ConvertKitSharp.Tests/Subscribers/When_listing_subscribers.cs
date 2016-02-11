using Machine.Specifications;
using ConvertKitSharp.Services;
using ConvertKitSharp.Entities;

namespace ConvertKitSharp.Tests.Subscribers
{
    [Subject(typeof(ConvertKitSubscriberService))]
    class When_listing_subscribers
    {
        Establish context = () =>
        {
            Service = new ConvertKitSubscriberService(Utils.ApiKey);
        };

        Because of = () =>
        {
            Result = Service.ListAsync().Await().AsTask.Result;
        };

        It should_list_subscribers = () =>
        {
            Result.ShouldNotBeNull();
            Result.Page.ShouldEqual(1);
        };

        Cleanup after = () =>
        {

        };

        static ConvertKitSubscriberService Service;

        static ConvertKitSubscriberList Result;
    }
}
