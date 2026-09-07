public class FileLogger
{
   public void LogMessage(string aStackTrace)
   {

   }
}
public class ExceptionLogger
{
   public void LogIntoFile(Exception aException)
   {
      FileLogger objFileLogger = new FileLogger();
      objFileLogger.LogMessage(GetUserReadableMessage(aException));
   }
   private GetUserReadableMessage(Exception ex)
   {
      string strMessage = string. Empty;

      ....
      ....
      return strMessage;
   }
}

public class DataExporter
{
   public void ExportDataFromFile()
   {
   try {

   }
   catch(Exception ex)
   {
      new ExceptionLogger().LogIntoFile(ex);
   }
}
}

public class DbLogger
{
   public void LogMessage(string aMessage)
   {

   }
}
public class FileLogger
{
   public void LogMessage(string aStackTrace)
   {

   }
}
public class ExceptionLogger
{
   public void LogIntoFile(Exception aException)
   {
      FileLogger objFileLogger = new FileLogger();
      objFileLogger.LogMessage(GetUserReadableMessage(aException));
   }
   public void LogIntoDataBase(Exception aException)
   {
      DbLogger objDbLogger = new DbLogger();
      objDbLogger.LogMessage(GetUserReadableMessage(aException));
   }
   private string GetUserReadableMessage(Exception ex)
   {
      string strMessage = string.Empty;

      ....
      ....
      return strMessage;
   }
}
public class DataExporter
{
   public void ExportDataFromFile()
   {
      try {

      }
      catch(IOException ex)
      {
         new ExceptionLogger().LogIntoDataBase(ex);
      }
      catch(Exception ex)
      {
         new ExceptionLogger().LogIntoFile(ex);
      }
   }
}

public interface ILogger
{
   void LogMessage(string aString);
}
public class DbLogger: ILogger
{
   public void LogMessage(string aMessage)
   {

   }
}
public class FileLogger: ILogger
{
   public void LogMessage(string aStackTrace)
   {

   }
}

public class ExceptionLogger
{
   private ILogger _logger;
   public ExceptionLogger(ILogger aLogger)
   {
      this._logger = aLogger;
   }
   public void LogException(Exception aException)
   {
      string strMessage = GetUserReadableMessage(aException);
      this._logger.LogMessage(strMessage);
   }
   private string GetUserReadableMessage(Exception aException)
   {
      string strMessage = string.Empty;

      ....
      ....
      return strMessage;
   }
}
public class DataExporter
{
   public void ExportDataFromFile()
   {
      ExceptionLogger _exceptionLogger;
      try {

      }
      catch(IOException ex)
      {
         _exceptionLogger = new ExceptionLogger(new DbLogger());
         _exceptionLogger.LogException(ex);
      }
      catch(Exception ex)
      {
         _exceptionLogger = new ExceptionLogger(new FileLogger());
         _exceptionLogger.LogException(ex);
      }
   }
}

public class EventLogger: ILogger
{
   public void LogMessage(string aMessage)
   {

   }
}
public class DataExporter
{
   public void ExportDataFromFile()
   {
      ExceptionLogger _exceptionLogger;
      try {

      }
      catch(IOException ex)
      {
         _exceptionLogger = new ExceptionLogger(new DbLogger());
         _exceptionLogger.LogException(ex);
      }
      catch(SqlException ex)
      {
         _exceptionLogger = new ExceptionLogger(new EventLogger());
         _exceptionLogger.LogException(ex);
      }
      catch(Exception ex)
      {
         _exceptionLogger = new ExceptionLogger(new FileLogger());
         _exceptionLogger.LogException(ex);
      }
   }
}
