# Gescor (Sugar cane harvest management)

This web application manages the process of the harvest of sugar cane.

## Features

- User management.
- Harvest management.
- Equipment management.
- Harvester operators management.
- Plans for equipment and operators.
- Report daily task for harvesters.
- Output several reports with the information of all the process.

## Technical requirements

- .Net Framework 4.5
- Microsoft SQL server

## Install

- Create a database called "gescor" in your SQL server.
- Run in the database the script [DatabaseStructureCreation.sql](data/DatabaseStructureCreation.sql) to create the database tables.
- Run in the database the script [BasicData.sql](data/BasicData.sql) to add initial data to the database.
- The administrator credentials are USER: `admin`, PASSWORD: `admin123*`
