
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace BlazorApp9
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddRazorComponents().AddServerComponents();
			builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
			builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddHttpContextAccessor();
			builder.Services.AddServerSideBlazor();

			WebApplication app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
				app.UseResponseCompression();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseRouting();
			app.UseAntiforgery();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();
			app.MapRazorComponents<App>();

			app.Run();
		}
	}
}
