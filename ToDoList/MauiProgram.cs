using Microsoft.Extensions.Logging;
// Подключение пространства имен для работы с системой логирования в .NET.

namespace ToDoList
// Объявление пространства имен ToDoList для организации кода в логические группы.

{
    public static class MauiProgram
    // Объявление статического класса MauiProgram, который является точкой входа в приложение MAUI.

    {
        public static MauiApp CreateMauiApp()
        // Объявление статического метода CreateMauiApp, который конфигурирует и создает экземпляр MauiApp.

        {
            var builder = MauiApp.CreateBuilder();
            // Создание и инициализация билдера для настройки MauiApp.

            builder
                .UseMauiApp<App>()
                // Указание основного класса приложения для MAUI.

                .ConfigureFonts(fonts =>
                // Конфигурация шрифтов, которые будут использоваться в приложении.

                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    // Добавление шрифта OpenSans-Regular с псевдонимом OpenSansRegular.

                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    // Добавление шрифта OpenSans-Semibold с псевдонимом OpenSansSemibold.
                });

#if DEBUG
            builder.Logging.AddDebug();
            // Добавление логирования отладки в конфигурацию билдера при компиляции в режиме DEBUG.
#endif

            return builder.Build();
            // Сборка и возвращение сконфигурированного экземпляра MauiApp.
        }
    }
}
