# UmbracoExport

This project is to demonstrate exporting the Umbraco Content tree into Json or CSV. A simple page using a SurfaceController for post back as been created for this (http://localhost:62407/export-page/).

As the task was set out to demonstrate a SurfaceController, I have complete the export using a front facing option. However I would normally try to handle this by adding the functionality directly into the umbraco backend, Ideally as a plugin inheriting from the UmbracoAuthorizedJsonController.

# Project Setup

The project is running on a CE database, so should work out of the box. It is also using gulp to complie Sass and JS. The latest version of Node.js should be installed on the developers machine for the complier and bunlder to work.

To access the export page (http://localhost:62407/export-page/), you will first need to be logged into the umbraco admin section, test account details below:
Username: Admin@umbracoexport.com
Password: P@ssw0rd01!


