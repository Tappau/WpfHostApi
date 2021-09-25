# WpfHostApi

## Description

Host an API within a WPF application using GenericHost of net5

- When the application is launched it opens as a tray app
- On startup it starts up an API Server hosted with Kestrel
- As WPF Generic Exception Handler, with window example.
- Possible to override/implement the Log() function in order to Log to however the WPF app wants to log.

## API

- This is currently set to run on <http://localhost:5000>
- Exposes a swagger endpoint reachable at <http://localhost:5000/swagger> (**_In Dev mode only_**)
- Uses the default WeatherForecast controller from basic API project template as an example

### Appreciations

- TrayApp is influenced by Kazuhiro Fujieda's repo <https://github.com/fujieda/SystemTrayApp.WPF/tree/main/SystemTrayApp.WPF>

### Dependencies

- Microsoft.Toolkit.Mvvm
- Microsoft.Xaml.Behaviors.Wpf
- Swashbuckle.AspNetCore
