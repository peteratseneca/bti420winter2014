### Week 10 code examples

**ImportCSV**

Import comma-separated-values (plain text) data.

Features:
- a 'csv' plain text data file, in the App_Data folder
- uses the CsvHelper package that you can find on NuGet
- access the file system; see the store initializer class
- the process uses familiar constructs and app infrastructure

**SecurityUsersAndRoles**

Work with users, and roles.

Features:
- Uses 'local accounts'
- StoreInitializer creates Roles, and some initial users
- ApplicationUser class has additional properties
- When registering for a new account, the new user is placed in the 'Student' role
- The 'admin' user can register new users in the 'Faculty' role
- Conditional menu choices; see _Layout.cshtml
