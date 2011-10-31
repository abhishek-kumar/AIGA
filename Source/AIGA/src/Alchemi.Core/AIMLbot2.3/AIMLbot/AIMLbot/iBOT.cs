using System;
using System.Collections.Generic;
using System.Text;
using AIMLbot;

namespace AIMLBot
{
    /// <summary>
    /// an eduGRID initiative.
    /// class written by Abhishek Kumar on March 5 2007.
    /// iBOT is an encapsulator for AIMLBot.bot and related functions
    /// </summary>
    [Serializable]
    public class iBOT
    {
        //member variables
        private Bot bot;
        private User user;
        private Request lastRequest = null;
        private Result lastResult = null;
        private string LogMsgs = "";//this will be visible to user
        private string InternalLog = "";
        private string ExceptionMsgs = "";//in case initialization fails
        private string AIMLSourcePath = "C:\\aiml";
        //private string AIMLSourcePath = "D:\\Tasks to do\\Work Area\\imaginecup\\Working Source - eduGRID Framework\\Alchemi-1.0.5-src-net-2.0\\src\\AIMLGUI2.3\\AIMLGUI\\AIMLGUI\\bin\\Debug\\aiml";

        public bool initialized = false;
        
        //constructors
        public iBOT()
        { }
        public iBOT(string PathToAIML)
        {
            AIMLSourcePath = PathToAIML;
        }

        //methods
        public bool initialize_iBOT()
        {

            //initialize bot
            bot = new Bot();
            bot.loadSettings(); //TODO: change settings.xml in config

            //user settings
            user = new User("DefaultUser", this.bot);

            //Log writer event setting
            bot.WrittenToLog += new Bot.LogMessageDelegate(bot_Log);

            //Initialize the bot's Mind
            try
            {
                AIMLbot.Utils.AIMLLoader loader = new AIMLbot.Utils.AIMLLoader(this.bot);
                this.bot.isAcceptingUserInput = false;
                loader.loadAIML(AIMLSourcePath);
                this.bot.isAcceptingUserInput = true;
            }
            catch (Exception ex)
            {
                ExceptionMsgs += DateTime.Now.ToString() + ">> " + ex.Message + Environment.NewLine;
                return false;
            }
            //the bot is ready to serve!
            initialized = true;
            return true;
        }

        public string Query(string querystring)
        {
            if (this.bot.isAcceptingUserInput)
            {
                Request myRequest = new Request(querystring, this.user, this.bot);
                Result myResult = this.bot.Chat(myRequest);
                this.lastRequest = myRequest;
                this.lastResult = myResult;
                
                //log the request made
                System.IO.File.AppendAllText(AIMLSourcePath + "\\Executor_Info", DateTime.Now.ToString() + ">>  " + querystring + Environment.NewLine + "            >> " + myResult.Output);
                
                return myResult.Output;
                
            }
            else
            {
                return "Bot not expecting Input!";
                //todo add exception here
            }

        }

        //events
        void bot_Log()
        {
            LogMsgs += DateTime.Now.ToString() + ">> " + this.bot.LastLogMessage + Environment.NewLine;
        }
    }


}
