using AdvancedConcepts.Models.Enums;
using AdvancedConcepts.Tasks;

namespace AdvancedConcepts
{
    /// <summary>
    /// Presenter of a menu and navigation to appropriate Task
    /// </summary>
    internal class App
    {
        private readonly Events _events;
        private readonly Types _types;
        private readonly AnonymousMethod _anonymousMethod;
        private readonly Delegates _delegates;
        private readonly Queries _queries;
        private readonly Records _records;
        private readonly PatternMatching _patternMatching;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="events"> The instance of Events </param>
        /// <param name="types"> The instance of types</param>
        /// <param name="anonymousMethod"> The instance of anonymousMethods</param>
        /// <param name="delegates"> The instance of Delegates</param>
        /// <param name="queries"> The instance of Queries</param>
        /// <param name="records"> The instance of records</param>
        /// <param name="patternMatching"> The instance of pattern Matching</param>
        public App(
            Events events,
            Types types,
            AnonymousMethod anonymousMethod,
            Delegates delegates,
            Queries queries,
            Records records,
            PatternMatching patternMatching)
        {
            this._events = events;
            this._types = types;
            this._anonymousMethod = anonymousMethod;
            this._delegates = delegates;
            this._queries = queries;
            this._records = records;
            this._patternMatching = patternMatching;
        }

        /// <summary>
        ///  execution loop presenting a menu and navigating appropriate Task
        /// </summary>
        public void Execute()
        {
            TaskOptions? taskOptions = default;
            do
            {
                Console.WriteLine(@"============================================
1. Events.
2. Dynamic and Var KeyWord.
3. Anonymous Methods.
4. Advanced Delegates Concept.
5. Lambda Expressions
6. Manipulating Record.
7. Advanced Pattern Matching.
8. Exit.
============================================");
                taskOptions = UserInput.ReadEnum<TaskOptions>("Enter a choice: ");

                switch (taskOptions)
                {
                    case TaskOptions.Events:
                        this._events.ExecuteEvent();
                        break;
                    case TaskOptions.Types:
                        this._types.ExecuteTypes();
                        break;
                    case TaskOptions.AnonymousMethods:
                        this._anonymousMethod.ExecuteAnonymousMethod();
                        break;
                    case TaskOptions.LambdaExpressions:
                        this._queries.ExecuteQueries();
                        break;
                    case TaskOptions.Delegates:
                        this._delegates.ExecuteDelegates();
                        break;
                    case TaskOptions.Records:
                        this._records.ExecuteRecord();
                        break;
                    case TaskOptions.PatternMatching:
                        this._patternMatching.ExecutePatternMatching();
                        break;
                    case TaskOptions.Exit:
                        Console.WriteLine("Exiting the app....");
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice");
                        break;
                }

                UserInput.WaitAndClear();
            }
            while (taskOptions != TaskOptions.Exit);
        }
    }
}
