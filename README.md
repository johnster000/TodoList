TodoList

Steps to run:
1. Clone project to local
2. Open in Visual Studio 2022
3. Run following commands in Nuget Package Manager to install dependencies
  - Install-Package Dapper
  - Install-Package Dapper.Contrib
  - Install-Package System.Data.SqlClient
4. Create the LocalDB using the SQL Server Object Explorer in Visual Studio (Name I used was "ToDoList")
  - Should you wish to run this from your own database server, simply edit the file "~\Helpers\DBHelper.cs" and replace "DBserver" variable with your server name
5. Run the "CreateTaskItemsTable.sql" from the project root against the newly created DB to create the table (This will create the table for the model in your DB)
6. Start the App within Visual Studio

Working with the App:

The single page site is setup with 3 main parts:
  - Add New Item
  - Incomplete Items
  - Completed Items
  
Add New Item
  - Simply enter a description for the task into the provided text box and click the green "Add" button
  - When editing an existing item, the description will populate the text box and you can make any changes nessesary, and then update the item by clicking "update", or cancel the update by clicking "Cancel"

Incomplete Items
  - 3 options are available in this table: 
    - Edit (triggered by clicking on the description of the item)
    - Complete Item (triggered by clicking on the "Complete" button)
    - Delete (triggered by clicking on the "Delete" button)
  - Date Added is also shown for convinience and sorting purposes (task are sorted by newest to oldest by default)

Completed Items
  - Once an item has been completed, it will move to this list.
  - 2 options are available in this table: 
    - Uncomplete Item (triggered by clicking on the "Uncomplete" button, this will erase the "Date Complete" field and set the status back to incomplete, thus moving it back to the Incomplete Items table)
    - Delete Item (triggered by clicking on the "Delete" button)
  - For tracking reasons, I've also added a "Time To Close" field which calculates the total minutes elapsed between the time the task was created and the time it was completed
