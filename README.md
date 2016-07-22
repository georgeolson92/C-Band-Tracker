# C&#35; Band Tracker
#### By _George Olson_

### Description
_Track bands and the venues they play at!_

### Specifications
| Behavior | Input | Output |
|:---  | :---  | :----  |
|Adds a new band| `new band = "Grouplove"`| `"List of Bands: Grouplove"`|
|Removes a band| `remove band "Grouplove"`| `No bands.`|
|Edits band name| `band = "Grouplove", new name = "Grouphate"`| `"List of Bands: Grouphate"`|
|Adds a new venue| `new venue: name = "Roseland Theater"` | `"List of venues: Roseland Theater"`|
|Removes a venue| `remove venue "Roseland Theatre"`| `No venues.`|
|Edits venue name| `venue = "Roseland Theater", new name = "Roseland Theatre"`| `"List of venues: Roseland Theatre"`|
|Adds a venue to a list of band's played venues| `venue name = "Roseland Theater", band = "Grouplove";`| `"List of venues Grouplove has played at: Roseland Theater"`|
|Adds a band to a venue's list of concerts| `venue name = "Roseland Theater", band = "Grouplove";`| `"List of bands that have played at Roseland Theater: Grouplove"`|


### Setup/Installation Requirements

#### Step 1
**Windows Users:**
* Open PowerShell and ensure that C&#35; is installed (<a href="https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c">View link</a> for information on installing C&#35; in PowerShell)
* Ensure that Git project management is functioning (<a href="https://www.learnhowtoprogram.com/c/getting-started-with-c/git-project-setup-for-windows">View link</a> for information on setting up Git in PowerShell)
* Clone repository from github
* Change directory to project folder
* Enter "dnu restore" in PowerShell to restore dependences
* Enter "dnx kestrel" to compile code
* View "http://localhost:5004" in your default web browser

**Mac Users:**
* Please <a href="https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c">view link</a> for information on setting up your C&#35; environment on Mac.
* Open Terminal
* Clone repository from github
* Change directory to project folder
* Enter "dnu restore" in Terminal to restore dependences
* Enter "dnx kestrel" to compile code
* View "http://localhost:5004" in your default web browser

#### Step 2

Create the database using the following commands in PowerShell's SQLCMD:

* **CREATE DATABASE band_tracker;**
* **GO**
* **USE band_tracker;**
* **GO**
* **CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));**
* **CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));**
* **CREATE TABLE bands_venues (id INT IDENTITY(1,1), band_id INT, venue_id INT);**
* **GO**

### Known Bugs
No known bugs in current version.

### Support and Contact Details
You can reach me via email: **georgeolson92@gmail.com**

### Technologies Used
C&#35;, Nancy framework, HTML, Bootstrap framework, ASP.NET

#### License
MIT

Copyright (c) 2016 **_(George Olson)_**
