# CSharp-Selenium-RestSharp-BDD

### About
**Overview:** _C# UI and API with BDD testing framework sample._

**Systems under test:**
- UI: Oracle login application.
- API: Gorest.co.in Rest and GraphQL application.

**Technology stack:**
- Basic: C#, .NET 6, NUnit
- BDD: SpecFlow
- UI: Selenium
- API: RestSharp
- Reporting: Allure

## Locally on your machine
### Installation
1. Install [.NET](https://dotnet.microsoft.com/en-us/download).
2. Download the project.
3. Install dependencies with a terminal command `dotnet build` in the project's root folder.
4. Get your token for [GoRest](https://gorest.co.in/my-account/access-tokens) (You need to register/login first).
5. In the project's root folder, paste your token into `token.json` file as a value for the `token` key.
6. Additional step: You need to install [Allure](https://github.com/allure-framework/allure2), if you want to use it.

### Running tests
1. You can run whole test suite with `dotnet test` from the project's root folder.
2. As well, you can start prefered features, using `dotnet test --filter "Category=***"`. Instead of `***` you need to specify a tag. List of available tags: _api, rest, gql, ui_.

### After test
- Framework creates allure reports, that located in `allure-results` folder.
- To get the report in the HTML format, type `allure serve allure-results` into the terminal in the project's root folder.
- **Note: Allure folder would be cleared within the next test run.**

## Jenkins CI
### Installation
1. Install [Jenkins](https://www.jenkins.io).
2. Install default plugins in Jenkins.
3. As well there is a list of plugins that you need to install additionally via Jenkins > Manage Jenkins > Manage Plugins: Allure Jenkins Plugin, .NET SDK Support ,Git Plugin, GitHub plugin, HTML Publisher plugin.
4. In Jenkins > Manage Jenkins > Global Tool Configuration click on `.NET SDL installations...` button in `.NET SDK` section and add name `dnet`, choose Install automatically > Extract *.zip/*.tar.gz. You need to specify link. Choose your machine's OS and architecture from [this link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and take a link for the binary. Then apply and save.
5. Create a new Job with `Pipeline` type.
6. Job configuration:
- Enable `GitHub Project` checkbox and paste my project's git url
- Enable `This project is parameterised` checkbox and add a String parameter named `token`, it is important!
- Scroll down to the Pipeline section and choose `Pipeline script from SCM`, then choose Git as an option.
- Paste my project's url to the repo's url field: `https://github.com/artgrtmnk/CSharp-Selenium-RestSharp-BDD/` and specify the branch name a bit lower as: `*/main`.
- Apply and Save the pipeline.

### Running tests
1. Click on `Build with Parameters` in the left nav menu.
2. Paste your GoRest token into the token var field.
3. Click `Build` button

### After test
- Allure report would be generated automatically. The only thing you need to do is to click on `Allure Report` button in the left nav menu.
- **Note: Allure folder would be cleared within the next test run.**

## Post scriptum
**_Antipattern was used in this sample framework: Test scenarios from API feature files are running sequentially, just because that's a sample. Never do it in a real project. Each test scenario should be independent and all of the pre-conditions should be done within the Given steps!_**
