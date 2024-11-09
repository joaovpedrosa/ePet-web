using ePet.Repository;

namespace ePet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Registra o UserRepository
            builder.Services.AddTransient<UserRepository>();

            // Adiciona o suporte para sessões
            builder.Services.AddSession();

            // Cria o aplicativo
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Serve arquivos estáticos (CSS, JS, imagens, etc.)
            app.UseStaticFiles();

            // Configuração de rotas
            app.UseRouting();

            // Autorização
            app.UseAuthorization();

            // Configurações de Sessão
            app.UseSession();

            // Define a rota padrão
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Inicia o aplicativo
            app.Run();
        }
    }
}
