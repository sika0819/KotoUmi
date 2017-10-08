using System;
using Mono.Data.SqliteClient;
using UnityEngine;
using System.Data;

public class DB
{
    private static DB _instance;
    public static DB Instance{
       get {
            if (_instance == null)
            {
                _instance = new DB();
            }
            return _instance;
        }
    }
    // Location of database - this will be set during Awake as to stop Unity 5.4 error regarding initialization before scene is set
    // file should show up in the Unity inspector after a few seconds of running it the first time
    private string _sqlDBLocation = "";

    /// <summary>
    /// Table name and DB actual file name -- this is the name of the actual file on the filesystem
    /// </summary>
    private const string SQL_DB_NAME = "avg";

    // table name
    private const string SQL_TABLE_NAME = "juben";

    /// <summary>
    /// predefine columns here to there are no typos
    /// </summary>
    private const string COL_NAME = "name";  // using name as example of primary, unique, key

    /// <summary>
    /// DB objects
    /// </summary>
    private  IDbConnection _connection = null;
    private  IDbCommand _command = null;
    private  IDataReader _reader = null;
    private  string _sqlString;

    private  bool _createNewTavle = false;

    /// <summary>
    /// Awake will initialize the connection.  
    /// RunAsyncInit is just for show.  You can do the normal SQLiteInit to ensure that it is
    /// initialized during the Awake() phase and everything is ready during the Start() phase
    /// </summary>
    public void Open(string sqlpath)
    {

        // here is where we set the file location
        // ------------ IMPORTANT ---------
        // - during builds, this is located in the project root - same level as Assets/Library/obj/ProjectSettings
        // - during runtime (Windows at least), this is located in the SAME directory as the executable
        // you can play around with the path if you like, but build-vs-run locations need to be taken into account
         _sqlDBLocation = sqlpath;

        Debug.Log(_sqlDBLocation);
        SQLiteInit();
    }

    /// <summary>
    /// Clean up SQLite Connections, anything else
    /// </summary>
    public void OnDestroy()
    {
        SQLiteClose();
    }

 

    /// <summary>
    /// Basic initialization of SQLite
    /// </summary>
    private void SQLiteInit()
    {
        Debug.Log("SQLiter - Opening SQLite Connection");
        _connection = new SqliteConnection(_sqlDBLocation);
        _command = _connection.CreateCommand();
        string cmdText = "select * from juben";
        ExecuteNonQuery(cmdText);
    }

  
    public void ExecuteNonQuery(string commandText)
    {
        _connection.Open();
        _command.CommandText = commandText;
        var reader = _command.ExecuteReader();
        while (reader.Read()) {
            TextData textData = new TextData();
            
            if (!reader.IsDBNull(0)) {
                int tempID = reader.GetInt32(reader.GetOrdinal("ID"));
                textData.id = tempID;
            }
            int tempCid = reader.GetInt32(reader.GetOrdinal("CID"));
            textData.charNum = tempCid;
            Debug.Log(tempCid);

            string tempName = reader.GetString(reader.GetOrdinal("Name"));
            textData.Name = tempName;
            Debug.Log(textData.Name);

            string tempDialog = reader.GetString(reader.GetOrdinal("Text"));
            textData.TextContent = tempDialog;
            Debug.Log(tempDialog);

            string tempType = reader.GetString(reader.GetOrdinal("textType"));
            switch (tempType) {
                case "Dialog":
                    textData.dataType = DataType.Dialog;
                    break;
                case "Content":
                    textData.dataType = DataType.Content;
                    break;
                case "Choice":
                    textData.dataType = DataType.Choice;
                    break;
            }
            Debug.Log(textData.dataType);
            UIController.Instance.ShowText(textData);
        }
        _connection.Close();
    }

    /// <summary>
    /// Clean up everything for SQLite
    /// </summary>
    private void SQLiteClose()
    {
        if (_reader != null && !_reader.IsClosed)
            _reader.Close();
        _reader = null;

        if (_command != null)
            _command.Dispose();
        _command = null;

        if (_connection != null && _connection.State != ConnectionState.Closed)
            _connection.Close();
        _connection = null;
    }

}