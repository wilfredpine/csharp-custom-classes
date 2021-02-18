# CSharf Custom Classes

Custom classes for Windows Form Application in C# Developed by Wilfred V. Pine
@2020

[MIT License](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/LICENSE)

## [Classes](https://github.com/redmalmon/CSharf-Custom-Classes/tree/main/C-Sharf%20Classes/Classes)

### 1. [Database](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Database.cs) class - this is use for MySqlClient configurations, sql statements, & etc.

* Instantiation - creating an object `db` from a class type `Database` and instantiate using the `new` keyword.

see: [c-sharfcorner](https://www.c-sharpcorner.com/article/C-Sharp-object-instantiation-part-i-constructors/)

```c#
// instantiate an object `db` from `Database` class
Database db = new Database();
```

#### Using Database' Methods

- Sql Statements

* `select(string qry)` or select() method is use for `select` statements and this method return `MySqlDataReader` that reads a forward-only stream of rows from a MySQL database.

```c#
var reader = db.select("select * from users");
while (reader.Read())
{
    //reader["userid"].ToString();
}
```

* `save(string table, string[] column, string[] bind)` or save() method is use for `insert into` statements and does not return a value. This methods display a MessageBox for showing the result of your sql statement. The `table` parameter is use to pass your table_name from your database, while `column` parameter is use to pass your collection of column_name from your database table, and the `bind` parameter is for the collection of values of the columns.

```c#
string[] value = { txtUsername.Text, txtPassword.Text, cmbSex.Text };
string[] column = { "username", "password", "sex" };
db.save("users", column, value);
```

* `cud(string qry, string msg = "")`

```c#
db.cud("Sql Query Here","Successfully Saved/Updated/Deleted");

db.cud("INSERT INTO users (username,password,sex) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbSex.Text + "')","Successfully Saved");


```

* Display to DataGridView (datasource)

```c#
//optional
string[] customheader = { "User ID", "Username", "Gender" };
//the table methods
db.table("select userid,username,sex from users", dgvUsers, customheader);
```


### 2. [Date_time](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Date_time.cs) class - for date & time conversion

* 

### 3. [Public_variables](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Public_variables.cs) class - stored global variables

* 

### 4. [UI_events](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/UI_events.cs) class - form controls & events

* Instantiate

```c#
UI_events ui = new UI_events();
```

* MDI show form child

```c#
frmDashboard dash = new frmDashboard();
ui.FormShow(dash, "Fill");
```

* Show new Form & hide this

```c#
frmMain frmain = new frmMain();
ui.Show(frmain, this);
```

* Form Show Dialog

```c#
frmMain frmain = new frmMain();
ui.Dialog(frmain);
```

* Charting

```c#
void loadChartSample()
{
    /*
    * SERIES MALE
    */

    // Array Legend
    string[] X = { "BSIT", "BSED" };
    // Add item to array Legend
    X = X.Concat(new string[] { "AB" }).ToArray(); 
    // new X is "BSIT", "BSED", "AB"


    // Array Value
    int[] Y = { 12, 14 };
    // Add item to array
    Y = Y.Concat(new int[] { 2 }).ToArray(); 
    // Y = 12, 14, 2


    // Pass to Chart Methods = Male Series
    ui.chart(chartUser, "Male", X, Y, "Column");

    //_________________________________________________________________________________
    
    /*
    * NEW SERIES FEMALE
    */

    // new 
    string[] x2 = { "BSIT", "BSED", "AB" };
    int[] y2 = { 6, 0, 16 };

    // Female
    ui.chart(chartUser, "Female", x2, y2, "Column");
}
```

* Chart data from database

```c#
/*
* SERIES SEX
*/
string[] X = {};
int[] Y = {};

var reader = db.select("select count(*) as c, sex from users group by sex");
while (reader.Read())
{
    X = X.Concat(new string[] { reader["sex"].ToString() }).ToArray();
    Y = Y.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray();
}

// Chart Methods
// ChartSeries = "Sex"; ChartType = "Column";
ui.chart(chartUser, "Sex", X, Y, "Column");
```


### 5. [Upload](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Upload.cs) class - files & directories

* 

### 6. [Validations](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Validations.cs) class - keyboard events, mouse events, etc.

* Instantiate

```c#
Validations validate = new Validations();
```

* Empty input controls

```c#
TextBox[] txt = { txtUsername, txtPassword, txtCPassword };
ComboBox[] cmb = { cmbSex };
if (!validate.txtRequired(txt) || !validate.cmbRequired(cmb))
    return;
```

* Accepts Numbers & Letters Only

```c#
private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
{
    validate.alphanum(e);
}
```


## [Config](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Config.cs) Class

* Database Information (connection string)

```c#
/*
* Database Information
*/
public static string dbname = "dbinformation";
public static string dbuser = "root";
public static string dbpassword = "";
```

* Upload Directories & Validations

```c#
public static string upload_path = @"c:\C-Sharf Classes\";
public static string allowedImage = "Image Files|*.jpg;*.jpeg;*.png";
public static string allowedFile = "Excel Files(.xls ,.xlsx)| *.xls ;*.xlsx|PDF Files(.pdf)|*.pdf|Text Files(*.txt)|*.txt|Word Files(.docx ,.doc)|*.docx;*.doc";
```
