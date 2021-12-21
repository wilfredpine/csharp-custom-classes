# CSharf Custom Classes

Custom classes for Windows Form Application in C# Developed by Wilfred V. Pine
@2020

[MIT License](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/LICENSE)

## [Classes](https://github.com/redmalmon/csharp-custom-classes/tree/main/Classes)

### 1. [Database](https://github.com/redmalmon/csharp-custom-classes/blob/main/Classes/Database.cs) class - this is use for MySqlClient configurations, sql statements, & etc. This will also included the loading of data to a form control including dataGridView and comboBox.

* Instantiation - creating an object `db` from a class type `Database` and instantiate using the `new` keyword.

see: [c-sharfcorner](https://www.c-sharpcorner.com/article/C-Sharp-object-instantiation-part-i-constructors/)

```c#
// instantiate an object `db` from `Database` class
Database db = new Database();
```

#### Using Database' Methods

Sql Statements

* `select(string qry)` or select() method is use for `select` statements and this method return `MySqlDataReader` that reads a forward-only stream of rows from a MySQL database.

```c#
var reader = db.select("select * from users");
while (reader.Read())
{
    //reader["userid"].ToString();
}
```

* `save(string table, string[] column, string[] bind)` or save() method is use for `insert into` statements and does not return a value. This methods display a MessageBox for showing the result of your sql statement. 

The `table` parameter is use to pass your table_name from your database, while `column` parameter is use to pass your collection of column_name from your database table, and the `bind` parameter is for the collection of values of the columns.

```c#
string[] value = { txtUsername.Text, txtPassword.Text, cmbSex.Text };
string[] column = { "username", "password", "sex" };
db.save("users", column, value);
```

* `cud(string qry, string msg = "")` or cud() method is use for your `insert into` , `update` , and `delete` statements. This method also does not return a value. This methods display a MessageBox for showing the result of your sql statement, or passing your custom notification message (optional) using `msg` parameter.

```c#
db.cud("Sql Query Here","Custom Notification Message");
//or
db.cud("Sql Query Here");
```

```c#
db.cud("INSERT INTO users (username,password,sex) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbSex.Text + "')","Successfully Saved");
```

* `table(string qry, DataGridView dgv, string[] header = null)` or table() method is use for displaying data to DataGridView Control using the DataSource properties.

The `qry` parameter use for your sql satements `select`. The `dgv` parameter is use to pass the name of your DataGridView Control, while the `header` parameter (optional) is use to display the custom header name for your DataGridView display.

```c#
//using custom header
string[] customheader = { "User ID", "Username", "Gender" };
//the table methods
db.table("select userid,username,sex from users", dgvUsers, customheader);
```

```c#
//the table methods without custom header
db.table("select userid,username,sex from users", dgvUsers);
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

* `FormShow(Form frm, string dstyle = "Fill")` or FormShow() methods is use for displaying form child to your MdiParent Form.

Instantiate an object `dash` of a form `frmDashboard`.
```c#
frmDashboard dash = new frmDashboard();
```
Passing object `dash` to the first parameter, and "Top" (`DockStyle` property value) to second parameter (Optional). Top property value is use for Dock properties of a form child. The default Dock property value is `DockStyle.Fill` or `Fill`.
```c#
ui.FormShow(dash, "Top");
```

```c#
// Fill
frmDashboard dash = new frmDashboard();
ui.FormShow(dash);
```

* `Show(Form frmNew, Form frmOld)` or Show() method is simply use for displaying new Form and hiding active Form. 

```c#
frmMain frmain = new frmMain();
ui.Show(frmain, this);
//behind the methods
//frmain.Show();
//this.Hide();
```

* `Dialog(Form frm)` or Dialog() methods use for displaying Form as Dialog.

```c#
frmMain frmain = new frmMain();
ui.Dialog(frmain);
```

#### Chart

* `chart(Chart chart, string SeriesName, string[] x, int[] y, string chartType = "Column")` or chart() method

The `chart` parameter is the name of your Chart Control. You can add a Serries by passing to `SeriesName` parameter and AddXY using `x` and `y` parameter. `x` is the legend, name or label of every data you want to display while `y` is the number value or count.

Example: 

```c#
void loadChartSample()
{
    /*
    * SERIES 'MALE'
    */
    // Array Legend
    string[] X = { "BSIT", "BSED", "AB" };
    // Array Value
    int[] Y = { 12, 14, 9 };
    // Pass to Chart Methods = Male Series
    ui.chart(chartUser, "Male", X, Y, "Pie");
    //_________________________________________________________________________________
    /*
    * NEW SERIES 'FEMALE'
    */
    string[] x2 = { "BSIT", "BSED", "AB" };
    int[] y2 = { 6, 0, 16 };
    // Female Series
    ui.chart(chartUser, "Female", x2, y2, "Pie");
}
```

How to add an item to array?

```c#
string[] X = { "BSIT", "BSED" };
// Add 1 item to array X
X = X.Concat(new string[] { "AB" }).ToArray(); 
// The new X is { "BSIT", "BSED", "AB" }

int[] Y = { 12, 14 };
// Add 1 item to array Y
Y = Y.Concat(new int[] { 2 }).ToArray(); 
// Y = 12, 14, 2
```

* Chart data from database

```c#
/*
* SERIES SEX
*/
//initialized empty array
string[] X = {};
int[] Y = {};

var reader = db.select("select count(*) as c, sex from users group by sex");
while (reader.Read())
{
    X = X.Concat(new string[] { reader["sex"].ToString() }).ToArray();
    Y = Y.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray();
}
// Chart Methods
// ChartSeries = "Sex"; ChartType = "Pie";
ui.chart(chartUser, "Sex", X, Y, "Pie");
```


### 5. [Upload](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Upload.cs) class - files & directories

* 

### 6. [Validations](https://github.com/redmalmon/CSharf-Custom-Classes/blob/main/C-Sharf%20Classes/Classes/Validations.cs) class - keyboard events, mouse events, etc.

* Instantiate

```c#
Validations validate = new Validations();
```

* The `txtRequired(TextBox[] txt, string msg = "")` or txtTequired() method use to validate required input controls.

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

* Database Information use as connection string.

```c#
/*
* Database Information
*/
public static string dbname = "dbinformation";
public static string dbuser = "root";
public static string dbpassword = "";
```

* Upload Directories & Validations.

```c#
public static string upload_path = @"c:\C-Sharf Classes\";
public static string allowedImage = "Image Files|*.jpg;*.jpeg;*.png";
public static string allowedFile = "Excel Files(.xls ,.xlsx)| *.xls ;*.xlsx|PDF Files(.pdf)|*.pdf|Text Files(*.txt)|*.txt|Word Files(.docx ,.doc)|*.docx;*.doc";
```
