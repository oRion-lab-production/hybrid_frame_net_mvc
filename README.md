 Presentation Layer
======================

This documentation for rnd_app_presentation presentation layer, a simple technical specification. The design still in fresh, if you have any comments or ideas, feel free to open dicussion on it. TQ.

## Specimen
 - Please install .net 6 for env use
 - Please intall node.js

### 3rd Party Library use
 - log4net [https://logging.apache.org/log4net/]
 - Microsoft Dependency iInjection [https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage]
 - Newtonsoft [https://www.newtonsoft.com/json]
 - RestSharp [https://restsharp.dev/]

### 3rd Party wwwroot Library use
 - Bootstrap 4 [https://getbootstrap.com/docs/4.0/getting-started/introduction/]
 - jQuery [https://jquery.com]
 - vue.js (vue2) [https://v2.vuejs.org/]
 - axios [https://axios-http.com/docs/intro]
 - admin-lte (admin template) [https://adminlte.io/]
 - gulp.js [https://gulpjs.com/]
 - webpack [https://webpack.js.org/]
 - DataTable.js [https://datatables.net/]

![](/presentationLayer_flow.png)

### npm install
```
..\rnd_app_presentation\WebApp>npm i --legacy-peer-deps --force
..\rnd_app_presentation\WebApp>npm i -g gulp

```

 - use can use Task Runner Explorer install into visual studio [https://marketplace.visualstudio.com/items?itemName=MadsKristensen.TaskRunnerExplorer]

### run gulp
```
..\rnd_app_presentation\WebApp>gulp
```

### run webpack bundle
```
..\rnd_app_presentation\WebApp>npm run build
```

### edit api url
 - edit the rnd_app if u have your own url
```
  "ApiSettings": {
    "APIsUrl": {
      "rnd_app": "https://192.168.1.193/rnd_app/api/"
    }
  }
```
 - add into ApiSettings.cs for new url links in ```Abstraction.GenericModels.Configurations```
 ```
namespace Abstraction.GenericModels.Configurations
{
    public class ApiSettings
    {
        public APIsUrl APIsUrl { get; set; }

        public ApiSettings() { 
            APIsUrl = new APIsUrl();    
        }    
    }


    public class APIsUrl
    {
        public string rnd_app { get; set; }
    }
}
 ```
  - How to get ApiSettings, and configuration in program.cs
  ```
    var apiSetting = new ApiSettings();
    configuration.GetSection("ApiSettings").Bind(apiSetting);
    services.AddSingleton(apiSetting);
  ```
## Usage spec
### API Request Flow

![](/presentationLayer_apiRequestFlow.png)