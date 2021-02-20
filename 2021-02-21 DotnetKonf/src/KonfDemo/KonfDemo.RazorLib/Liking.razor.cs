using KonfDemo.Shared.Models.Liking;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KonfDemo.RazorLib
{
    public partial class Liking
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        IHttpClientFactory ClientFactory { get; set; }

        public LikingDto LikeResult { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = ClientFactory.CreateClient("ServerAPI");

            LikeResult = await client.GetFromJsonAsync<LikingDto>($"/api/liking/{Id}");
        }

        private async Task UpvoteAsync()
        {
            var client = ClientFactory.CreateClient("ServerAPI");
            var responseMessage = await client.SendAsync(
                new HttpRequestMessage
                {
                    Method = new HttpMethod("POST"),                   
                    RequestUri = new Uri($"/api/liking/{Id}/like")
                }
            );

            LikeResult = await responseMessage.Content.ReadFromJsonAsync<LikingDto>();
        }

        private async Task DownvoteAsync()
        {
            var client = ClientFactory.CreateClient("ServerAPI");
            var responseMessage = await client.SendAsync(
                new HttpRequestMessage
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"/api/liking/{Id}/dislike")
                }
            );

            LikeResult = await responseMessage.Content.ReadFromJsonAsync<LikingDto>();
        }
    }
}
