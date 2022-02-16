# CSharf Custom Classes

Custom [Classes](https://github.com/wilfredpine/csharp-custom-classes/tree/main/Classes) for Windows Form Application using C# in Object-Oriented Programming and Event-Driven approached Developed by Wilfred V. Pine
@2020


- You are free to contribute in this project library :)


[MIT License](https://github.com/wilfredpine/CSharf-Custom-Classes/blob/main/LICENSE)

## [Classes](https://github.com/wilfredpine/csharp-custom-classes/tree/main/Classes)

## How to use?
1. Download the [Classes](https://github.com/wilfredpine/csharp-custom-classes/tree/main/Classes) folder 
2. Create a Windows Form Application project for .Net Framework Desktop Application.
3. In your Solution Explorer, right click on your project and add a folder named "`Classes`"
4. Then right click on your created "`Classes`" folder and add existing item. Browse the classes that you downloaded from step 1.
5. From your project folder root directory (in oyur Solution Explorer), create a class named " [Config](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Config.cs) " and create a public instance of all the classes from [Classes](https://github.com/wilfredpine/csharp-custom-classes/tree/main/Classes) folder. See the code below:
```c#
    using Classes; // include the "Classes" folder
    namespace MySampleProject
    {
        class Config
        {
            /*
            * Database Information
            */
                private static string host = "localhost";
                private static string dbname = "dbinformation";
                private static string dbuser = "root";
                private static string dbpassword = "";
            /*
            * Classes
            */
                public Database db;
                public Validation validate;
                public Form_UI ui;
                public Visualizer visualizer;
                public Str_Date_Time date_time;
                public Upload upload;
            /*
            * Constructor
            */
                public Config()
                {
                    this.db = new Database(host, dbuser, dbpassword, dbname);
                    this.validate = new Validation();
                    this.ui = new Form_UI();
                    this.visualizer = new Visualizer();
                    this.date_time = new Str_Date_Time();
                    this.upload = new Upload();
                }
        }
    }
```
6. To your Form (example; FormLogin), create an instance of your [Config](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Config.cs) class.
```c#
    public partial class FormLogin : Form
    {
        Config config = new Config(); // your Config class

        public FormLogin()
        {
            InitializeComponent();
        }
```
7. You can now use [Database](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Database.cs) , [Validation](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Validation.cs) , [Visualizer](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Visualizer.cs) , [Upload](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Upload.cs) , [Date_Time](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Str_Date_Time.cs) , & [Form_UI](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Form_UI.cs) Class.
```c#
    config.db.....
    config.validate......
    config.ui......
    config.visualizer.....
    config.date_time.....
    config.upload.......
```


## 1. Using [Database](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Database.cs) class - this is use for MySqlClient configurations, sql statements, & etc. This will also included the loading of data to a form control including dataGridView and comboBox.

#### Requirements
* MySql Server ([Wamp Server](https://wampserver.aviatechno.net/?lang=es&prerequis=afficher))
* Install [MySql Connector .Net](https://dev.mysql.com/downloads/connector/net/)
* After you installed MySQL Connector .Net, go to `C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.27\Assemblies\v4.5.2\` and use the `MySql.Data.dll` as a reference for your project. 
    Note: `\v4.5.2\` is the .Net version of your project, you can use other version inside `C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.27\Assemblies\` folder.
* & Now you can use MySQLClient, Good Luck!

#####   tips: how to add reference for your project?
* On your solution explorer (on your project references), right click and choose add References, then browse the library you want to add (e.g. `C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.27\Assemblies\v4.5.2\MySql.Data.dll`)



#### Using Database' Methods

Sql Statements

* `select(string qry)` or select() method is use for `select` statements and this method return `MySqlDataReader` that reads a forward-only stream of rows from a MySQL database.

```c#
var reader = config.db.select("select * from users");
while (reader.Read())
{
    //reader["userid"].ToString();
}
```

* `save(string table, string[] column, string[] bind, string msg = "Successfully saved.")` or save() method is use for `insert into` statements and does not return a value. This methods display a MessageBox for showing the result of your sql statement. 

The `table` parameter is use to pass your table_name from your database, while `column` parameter is use to pass your collection of column_name from your database table, and the `bind` parameter is for the collection of values of the columns. Since the `msg` parameter has a default value, it is optional.

```c#
string[] column = { "username", "password", "sex" };
string[] value = { txtUsername.Text, txtPassword.Text, cmbSex.Text };
config.db.save("users", column, value); // config.db.save("users", column, value, "User successfully saved!");
```

* `cud(string qry, string msg = "Transaction Completed!")` or cud() method is use for your `insert into` , `update` , and `delete` statements. This method also does not return a value. This methods display a MessageBox for showing the result of your sql statement, or passing your custom notification message (optional) using `msg` parameter.

```c#
config.db.cud("Sql Query Here","Custom Notification Message");
//or
config.db.cud("Sql Query Here");
```

Example:
```c#
config.db.cud("INSERT INTO users (username,password,sex) VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbSex.Text + "')","User successfully saved!");
```


* `table(string qry, DataGridView dgv, string[] header = null)` or table() method is use for displaying data to a DataGridView Control using the DataSource properties.

The `qry` parameter use for your sql satement `select`. The `dgv` parameter is use to pass the name of your DataGridView Control, while the `header` parameter (optional) is use to display the collection of custom header name for your DataGridView display.

```c#
//using custom header
string[] customheader = { "User ID", "Username", "Gender" };
//the table methods
config.db.table("select userid,username,sex from users", dgvUsers, customheader); // dgvUsers is the name of your datagridview
```

```c#
//the table methods without custom header
config.db.table("select userid,username,sex from users", dgvUsers);
```

* `list(string qry, ComboBox comboBox)` or list() method is use to display data to your comboBox control as an items.

```c#
config.db.list("select course_name from courses", cmbCourse); // cmbCourse is the name of your comboBox control
```

* `exist(string qry)` or exist() method is use to validate if a data is existing in your database. It will return `true` if exist.
```c#
if(config.db.exist("select username from courses where username = '"+ txtusername.Text +"'"))
{
    MessageBox.Show("Username already exist!");
}else{
    // save
}
```

* `maxid(String column, String tbl)` or maxid() method is use to get the last inserted `id` in your database. The column parameter is the name of the column you want to select, and the tbl parameter is your table name.

```c#
int id = config.db.maxid('userid', 'users'); // it will return an int value
```




## 2. Using [Form_UI](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Form_UI.cs) class - 

This class includes the traditional way of displaying form. Also includes the advanced UI manipulation using MDI or Multiple Document Interface.

#### The Basic :

* `Show(Form frmNew, Form frmOld)` or Show() method is simply use for displaying new Form and hiding active Form. 
 - Behind the methods: `frmain.Show();` `this.Hide();`
```c#
frmMain frmain = new frmMain();
config.ui.Show(frmain, this); // or config.ui.Show(new frmMain());
```

* `Dialog(Form frm)` or Dialog() methods use for displaying Form as Dialog.

```c#
frmMain frmain = new frmMain();
config.ui.Dialog(frmain); // or config.ui.Show(new frmMain());
```
#### The MDI :

* `FormShow(Form frm, string dstyle = "Fill")` or FormShow() methods is use for displaying form child to your MdiParent Form.

Instantiate an object `dash` of a form `frmDashboard`.
```c#
frmDashboard dash = new frmDashboard();
```
Passing object `dash` to the first parameter, and "Top" (`DockStyle` property value) to second parameter (Optional). Top property value is use for Dock properties of a form child. The default Dock property value is `DockStyle.Fill` or `Fill`.
```c#
config.ui.FormShow(dash, "Top");
```

```c#
// Fill
frmDashboard dash = new frmDashboard();
config.ui.FormShow(dash); // or config.ui.FormShow(new frmDashboard());
```



## 3. Using [Visualizer](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Visualizer.cs) class - use for visualization of data.

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
    config.visualizer.chart(chartUser, "Male", X, Y, "Pie");
    //_________________________________________________________________________________
    /*
    * NEW SERIES 'FEMALE'
    */
    string[] x2 = { "BSIT", "BSED", "AB" };
    int[] y2 = { 6, 0, 16 };
    // Female Series
    config.visualizer.chart(chartUser, "Female", x2, y2, "Pie");
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

* Chart data from database (Dynamic)

```c#
/*
* SERIES 'MALE'
*/
//initialized empty array
string[] X = {};
int[] Y = {};

var reader = db.select("select count(*) as c, course from users where sex = 'MALE'");
while (reader.Read())
{
    X = X.Concat(new string[] { reader["course"].ToString() }).ToArray(); // string[] X = { "BSIT", "BSED", "AB" };
    Y = Y.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray(); // int[] Y = { 12, 14, 9 };
}
// Chart Methods
// ChartSeries = "MALE"; ChartType = "Bar"; // Chart type is optional, the default is column
config.visualizer.chart(chartUser, "MALE", X, Y, "Bar");

/*
* SERIES 'FEMALE'
*/
//initialized empty array
string[] x2 = {};
int[] y2 = {};

var reader = db.select("select count(*) as c, course from users where sex = 'FEMALE'");
while (reader.Read())
{
    x2 = x2.Concat(new string[] { reader["course"].ToString() }).ToArray(); // string[] x2 = { "BSIT", "BSED", "AB" };
    y2 = y2.Concat(new int[] { Int32.Parse(reader["c"].ToString()) }).ToArray(); // int[] y2 = { 6, 0, 16 };
}
// Chart Methods
// ChartSeries = "FEMALE"; ChartType = "Bar"; // Chart type is optional, the default is column
config.visualizer.chart(chartUser, "FEMALE", x2, y2, "Bar");
```



## 4. Using [Validations](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Validation.cs) class - use for validationg inputs (keyboard events, mouse events, etc.)


* The `txtRequired(TextBox[] txt, bool allow_message = false, string msg = "Please fillup required fields!")` or txtRequired() method use to validate required textbox controls. There is also validation for comboBox controls, the `cmbRequired(ComboBox[] cmb, bool allow_message = false, string msg = "Please select required fields!")` method. These functions return `false` if ther is an empty value in the fields.

```c#
TextBox[] txt = { txtUsername, txtPassword, txtCPassword };
ComboBox[] cmb = { cmbSex };
if (!config.validate.txtRequired(txt) || !config.validate.cmbRequired(cmb))
    return;
```

* The `alpha(KeyPressEventArgs e)` or alpha() Method is use to disable a series of keyboard characters except letters. To use this method, set a KeyPress events to your texbox and call the `alphanum(e)` methods to it's event handler.

```c#
private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
{
    config.validate.alphanum(e);
}
```



## 5. Using [Date_time](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Str_Date_Time.cs) class - for date & time format conversion

* 


## 6. Using [Upload](https://github.com/wilfredpine/csharp-custom-classes/blob/main/Classes/Upload.cs) class - working with files & directories

* 

