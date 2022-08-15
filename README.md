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

### Installation
1. Install [.NET](https://dotnet.microsoft.com/en-us/download)
2. Download the project.
3. Install dependencies with a terminal command `dotnet build` in the project's root folder.

### Running tests
1. You can run whole test suite with `dotnet test` from the project's root folder.
2. As well, you can start prefered features, using `dotnet test --filter "Category=***"`. Instead of `***` you need to specify a tag. List of available tags: _api, rest, gql, ui_.

### After test
- Framework creates allure reports, that located in `allure-results` folder.
- To get the report in the HTML format, type `allure serve allure-results` into the terminal in the project's root folder.
- **Note: Allure folder would be cleared within the next test run.**
