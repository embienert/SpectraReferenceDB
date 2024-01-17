# Spectra Reference Database

This project implements a client for interfacing with a Database backend 
for storing and managing References of different Spectra. Currently, 
SPC as well as text-based (tab, comma, semicolon, whitespace separated) 
files are supported as input.


## Installation
Different versions of the client are available under `Releases` on the
main GitHub page. For each release, under the `Assets` section, there is a ZIP
file containing the compiled program. The name of the file is
`SpectraReferenceDB-[version]`. <br>
It is recommended to always use the latest version. <br>
The tool is currently only available for windows operating systems. <br>
To install the program, follow the instructions below.

1. Download the compiled program. Make sure to download the compiled code and not the `Source code` ZIP files.
2. Move the downloaded ZIP file to the desired program location (e.g. `C:\ProgramFiles\` on your main drive)
3. Extract all the files to the selected directory. <br>NOTE: If you wish to update the program with a newer release, follow the same steps and simply choose to overwrite the existing files when extracting. Deleting existing local files before extracting is not recommended. This way you will keep the stored settings from previous versions.
4. It is recommended to create a shortcut of the `SpectraReferenceDB.exe` and move the shortcut to a convenient location (e.g. Desktop). The non-shortcut file must remain in the directory, otherwise the program cannot work.

## Setting up
Upon first execution of the program, you will be notified, that no database path has been specified.
By confirming with the `OK` button, you will be asked to provide the location of the database.
For this simply select the directory in which the database is currently stored. <br>
In case no database has been created yet, you still need to select a directory where you want the database to be stored.
For teams, it is recommended to choose a location on a shared drive. Remote servers, such as cloud drives
are currently not supported. <br>
After confirming the directory of the database, you may be asked if you want to create a database at the 
location, if no database file was found there. To do this, confirm the dialog with `Yes`. <br>
Upon completing these steps, you can start using the client.

## How it works
In the `References` panel on the left of the window, you can find a list of all references currently stored in the database. <br>
NOTE: the `ID` column is for internal use only, and does not have any relevance to the references themselves. <br>
The list can be sorted column-wise by clicking on the respective column headers. The client also includes a
filter/search option in the upper left area of the window. 
The references can be filtered by entering any phrase in the text field and applying with the `Search` button. <br>
The `Reference Data` panel on the right side of the window can be used to display and manage the entries in the database.
By clicking the `New Reference` button, you will be asked to select a file which contains the spectroscopy data. 
Currently, the program only supports `*.SPC`, as well as `*.DAT, *.TXT, *.RAMAN, *.CSV` files.
Depending on the file extension, the client employs different parsers. Reading `*.SPC` files is fully automated.
For all other file types you can either choose to let the number of header lines be automatically determined (recommended),
or manually define a number of header lines (including the column headers). Manually choosing is advisable if
the automatic detection fails to properly parse the data. Should the be multiple y-Columns in the selected file,
only the first will be considered. <br>
Once the client has finished reading the file, the data is displayed in the corresponding fields of the `Reference Data` panel,
and a basic plot of the data is shown in the bottom right. Before using the `Save` button to store the reference
in the database, it is recommended to fill out as many of the editable fields as possible. <br>
To display more information about an existing entry from the table, you can simply double-click on the corresponding row to open it in the
`Reference Data` panel on the right. When opening a reference in this manner, editing is disabled by default and the `Save/Save Changes` button
is replaced with a `Delete Entry` button. Using the `Delete Entry` will ask you for confirmation and then delete the entry **irreversibly**. <br>
The editing mode can be enabled by checking the `Enable Editing` checkbox at the bottom of the panel. This lifts
the writing protection of the data fields. Any changes can be committed directly to the database using the
`Save Changes` button. This process is also **irreversible**; Other than through manual backups, the database cannot
be returned to a previous state.

## Moving/Copying the database
The database itself can easily be copied or moved to another location. To do this, you need to copy **BOTH** the `references.db` file and
the `_files` directory. The `_files` directory contains a copy of all files added to the database and is required for the client
to show details and data plot within the client. This directory and all files within **must NOT** be renamed or deleted or the 
database client will break upon requesting details on the corresponding references. When moving or copying the database, make sure
this directory remains in the same location as the database. <br>
NOTE: When moving the database, it will likely be required to re-enter its location when starting the client for the first time afterwards.