namespace LanguageIntegratedQuery.Models.Enums
{
    /// <summary>
    /// Task options list
    /// </summary>
    internal enum TaskOption
    {
        /// <summary>
        /// Basic LINQ queries - filtering and selecting
        /// </summary>
        BasicLINQ = 1,

        /// <summary>
        /// Complex LINQ queries - Joining and Grouping
        /// </summary>
        ComplexLINQ,

        /// <summary>
        /// Object Queries - Queries on arrays object
        /// </summary>
        ObjectQuery,

        /// <summary>
        /// Query Optimization
        /// </summary>
        Optimization,

        /// <summary>
        /// Query builder - Fluent API
        /// </summary>
        QueryBuilder,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
