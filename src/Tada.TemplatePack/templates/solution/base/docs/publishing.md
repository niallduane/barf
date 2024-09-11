# Publishing the app

To create a new deployment package, first add the deployment targets appsettings to

- The database infrastructure
- The presentation api

alternatively, you can use env settings on deployment target.

Then execute the following command:

```
tada app package
```

This command creates (default location ./publish):

- A dbmigrations executable file based on EFbundle.
- The app build assets
