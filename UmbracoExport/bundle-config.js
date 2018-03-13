//https://www.npmjs.com/package/gulp-bundle-assets
module.exports = {
    bundle: {
        scriptsBundleMain: {
            scripts: [
                './Content/Scripts/vendors/jquery-3.1.1.min.js',
                './Content/Scripts/vendors/jquery-validation/jquery.validate.js',
                './Content/Scripts/vendors/jquery-validation/additional-methods.js',
                './Content/Scripts/vendors/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
                './Content/Scripts/vendors/bootstrap.js',
                './Content/Scripts/customs/umbraco-starterkit-app.js'
            ],
            options: {
                rev: false // {(boolean|string|Array)}
            }
        }
    }
};
