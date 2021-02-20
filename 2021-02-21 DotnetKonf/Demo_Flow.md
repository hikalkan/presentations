## Create Projects

* Create new project;
  * Name: KonfDemo.BlazorApp
  * Type: Blazor web assembly
* Create new project;
  * Name: KonfDemo.RazorLib
  * Type: Razor Class Library
* Add reference to RazorLib from BlazorApp
* Add to imports: @using KonfDemo.RazorLib
* Add `<Component1 />` to home page and test.

## Contact Form Component

**ContactForm.razor** (initial)

````html
<div class="well well-sm">
    <form class="form-horizontal" action="" method="post">
        <fieldset>
            <legend class="text-left">Contact us</legend>

            <!-- Name input-->
            <div class="form-group">
                <label class="col-md-3 control-label" for="name">Name</label>
                <div class="col-md-9">
                    <input id="name" name="name" type="text" placeholder="Your name" class="form-control">
                </div>
            </div>

			<!-- Email input-->
			<div class="form-group">
				<label class="col-md-3 control-label" for="email">Your E-mail</label>
				<div class="col-md-9">
					<input id="email" name="email" type="text" placeholder="Your email" class="form-control">
				</div>
			</div>

            <!-- Message body -->
            <div class="form-group">
                <label class="col-md-3 control-label" for="message">Your message</label>
                <div class="col-md-9">
                    <textarea class="form-control" id="message" name="message" placeholder="Please enter your message here..." rows="5"></textarea>
                </div>
            </div>

            <!-- Form actions -->
            <div class="form-group">
                <div class="col-md-12 text-left">
                    <button type="submit" class="btn btn-primary btn-lg">Submit</button>
                </div>
            </div>
        </fieldset>
    </form>
</div>
````

**ContactForm.razor** (final)

````html
<div class="well well-sm">
    <form class="form-horizontal" action="" method="post">
        <fieldset>
            <legend class="text-left">Contact us</legend>

            @PreFormArea

            <!-- Name input-->
            <div class="form-group">
                <label class="col-md-3 control-label" for="name">Name</label>
                <div class="col-md-9">
                    <input id="name" @bind="Model.Name" name="name" type="text" placeholder="Your name" class="form-control">
                </div>
            </div>

            @if(GetEmail)
            {
                <!-- Email input-->
                <div class="form-group">
                    <label class="col-md-3 control-label" for="email">Your E-mail</label>
                    <div class="col-md-9">
                        <input id="email" @bind="Model.Email" name="email" type="text" placeholder="Your email" class="form-control">
                    </div>
                </div>
            }

            <!-- Message body -->
            <div class="form-group">
                <label class="col-md-3 control-label" for="message">Your message</label>
                <div class="col-md-9">
                    <textarea class="form-control" @bind="Model.Message" id="message" name="message" placeholder="Please enter your message here..." rows="5"></textarea>
                </div>
            </div>

            <!-- Form actions -->
            <div class="form-group">
                <div class="col-md-12 text-left">
                    <button type="submit" class="btn btn-primary btn-lg" @onclick:preventDefault @onclick="OnFormSubmit">Submit</button>
                </div>
            </div>
        </fieldset>
    </form>
</div>

@code {

    [Parameter]
    public bool GetEmail { get; set; } = true;

    [Parameter]
    public EventCallback<ContactFormResultModel> OnSubmit { get; set; }

    [Parameter]
    public RenderFragment PreFormArea { get; set; }

    private ContactFormResultModel Model { get; set; } = new ContactFormResultModel();

    private async Task OnFormSubmit(MouseEventArgs e)
    {
        //TODO: Send form to the server...

        await OnSubmit.InvokeAsync(Model);
    }

    public void ClearForm()
    {
        Model = new ContactFormResultModel();
    }
}
````

**Contact.razor page**

````html
@page "/contact"

@if (contactFormResult != null)
{
    <div class="alert alert-success">
        Thank you @contactFormResult.Name for contacting us :)
    </div>
}
else
{
    <ContactForm @ref="contactForm" OnSubmit="ContactFormSubmitted">
        <PreFormArea>
            <div class="alert alert-info">
                Hello, please write us what do you think about our website...
            </div>            
        </PreFormArea>
    </ContactForm>
    <button class="btn btn-secondary" @onclick="() => contactForm.ClearForm()">Clear</button>
}

@code{

    private ContactForm contactForm;
    private ContactFormResultModel contactFormResult;

    private void ContactFormSubmitted(ContactFormResultModel result)
    {
        contactFormResult = result;
    }
}
````

**ContactFormResultModel.cs**

````csharp
public class ContactFormResultModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
````

## Like Component

* Create a `KonfDemo.Shared` project, move `LikingDto` to the shared, reference from server and blazor apps.

**Liking.razor** (initial)

```html
<span class="oi oi-thumb-up"></span> 0
<span class="oi oi-thumb-down"></span> 0
```
**Liking.razor** (final)

````html
@if (LikeResult != null)
{
    <span class="oi oi-thumb-up like-button @(LikeResult.LikeCount > LikeResult.DislikeCount ? "highlight" : "")" @onclick="UpvoteAsync"></span> @LikeResult.LikeCount
    <span class="oi oi-thumb-down like-button @(LikeResult.LikeCount < LikeResult.DislikeCount ? "highlight" : "")" @onclick="DownvoteAsync"></span> @LikeResult.DislikeCount
}
````

**Liking.razor.cs**

````csharp
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

            LikeResult = await client.GetFromJsonAsync<LikingDto>($"https://localhost:44357/api/liking/{Id}");
        }

        private async Task UpvoteAsync()
        {
            var client = ClientFactory.CreateClient("ServerAPI");
            var responseMessage = await client.SendAsync(
                new HttpRequestMessage
                {
                    Method = new HttpMethod("POST"),                   
                    RequestUri = new Uri($"https://localhost:44357/api/liking/{Id}/like")
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
                    RequestUri = new Uri($"https://localhost:44357/api/liking/{Id}/dislike")                    
                }
            );

            LikeResult = await responseMessage.Content.ReadFromJsonAsync<LikingDto>();
        }
    }
}
````

**Liking.razor.css**

````css
.like-button {
    cursor: pointer;
    margin: 5px;
}

    .like-button.highlight {
        font-size: 1.2em;
        color: blue;
    }
````

**Program.cs** in the BlazorApp (configure http client)

````csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KonfDemo.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            builder.Services.AddHttpClient(
                "ServerAPI",
                client => client.BaseAddress = new Uri("https://localhost:44357/")
            );

            await builder.Build().RunAsync();
        }
    }
}
````

**wwwroot/sample-data/weather.json**

````json
[
  {
    "id": "1",
    "date": "2018-05-06",
    "temperatureC": 1,
    "summary": "Freezing"
  },
  {
    "id": "2",
    "date": "2018-05-07",
    "temperatureC": 14,
    "summary": "Bracing"
  },
  {
    "id": "3",
    "date": "2018-05-08",
    "temperatureC": -13,
    "summary": "Freezing"
  },
  {
    "id": "4",
    "date": "2018-05-09",
    "temperatureC": -16,
    "summary": "Balmy"
  },
  {
    "id": "5",
    "date": "2018-05-10",
    "temperatureC": -2,
    "summary": "Chilly"
  }
]
````

**FetchData.razor**

````html
@page "/fetchdata"
@inject HttpClient Http

<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from the server.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
            <tr>
                <td>@forecast.Date.ToShortDateString()</td>
                <td>@forecast.TemperatureC</td>
                <td>@forecast.TemperatureF</td>
                <td>@forecast.Summary</td>
                <td><Liking Id="@("WeatherForecast_" + forecast.Id.ToString())" /></td>
            </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
````

CORS setting:

````csharp
options.AddPolicy("DefaultCors", builder =>
{
    builder
        .WithOrigins("https://localhost:44304")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});
````

* Move Counter.razor to the razor class Library
* Set AdditionalAssemblies to make route working

````html
<Router AppAssembly="@typeof(Program).Assembly" 
        AdditionalAssemblies="new[] { typeof(KonfDemo.RazorLib.Liking).Assembly }"
        PreferExactMatches="@true">
````



