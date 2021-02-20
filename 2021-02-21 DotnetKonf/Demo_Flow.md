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
    <ContactForm OnSubmit="ContactFormSubmitted">
        <PreFormArea>
            <div class="alert alert-info">
                Hello, please write us what do you think about our website...
            </div>            
        </PreFormArea>
    </ContactForm>
}

@code{
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





