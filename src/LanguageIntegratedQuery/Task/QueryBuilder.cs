using System.Linq.Expressions;
using LanguageIntegratedQuery.Models.Enums;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Provides a fluent interface to build and execute LINQ queries.
    /// </summary>
    /// <typeparam name="T">The type of data in the query.</typeparam>
    internal class QueryBuilder<T>
    {
        private IQueryable<T> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="data">The collection of data to query.</param>
        public QueryBuilder(IEnumerable<T> data)
        {
            this._query = data.AsQueryable();
        }

        /// <summary>
        /// Filters the data based on a specified condition.
        /// </summary>
        /// <param name="condition">The filter condition expression.</param>
        /// <returns>The current query builder instance.</returns>
        public QueryBuilder<T> Filter(Expression<Func<T, bool>> condition)
        {
            this._query = this._query.Where(condition);
            return this;
        }

        /// <summary>
        /// Dynamically filters the query based on a specific property, a comparison condition, and a target value.
        /// </summary>
        /// <typeparam name="TProperty">The data type of the property being filtered.</typeparam>
        /// <param name="property">An expression pointing to the entity property (e.g., x => x.Name).</param>
        /// <param name="condition">The comparison rule to apply (e.g., Contains, GreaterThanOrEqualTo).</param>
        /// <param name="value">The actual value to compare the property against.</param>
        /// <returns>The updated QueryBuilder instance for method chaining.</returns>
        public QueryBuilder<T> Filter<TProperty>(
    Expression<Func<T, TProperty>> property,
    FilterOptions condition,
    TProperty value)
        {
            var parameter = property.Parameters[0];
            var propertyExpression = property.Body;
            var valueExpression = Expression.Constant(value);

            Expression filterExpression;

            switch (condition)
            {
                case FilterOptions.GreaterThanOrEqualTo:
                    filterExpression = Expression.GreaterThanOrEqual(
                        propertyExpression,
                        valueExpression);
                    break;

                case FilterOptions.LessThanOrEqualTo:
                    filterExpression = Expression.LessThanOrEqual(
                        propertyExpression,
                        valueExpression);
                    break;

                case FilterOptions.Contains:
                    filterExpression = Expression.Call(
                        propertyExpression,
                        nameof(string.Contains),
                        null,
                        valueExpression);
                    break;

                case FilterOptions.StartsWith:
                    filterExpression = Expression.Call(
                        propertyExpression,
                        nameof(string.StartsWith),
                        null,
                        valueExpression);
                    break;

                case FilterOptions.EndsWith:
                    filterExpression = Expression.Call(
                        propertyExpression,
                        nameof(string.EndsWith),
                        null,
                        valueExpression);
                    break;

                default:
                    throw new ArgumentException("Invalid filter condition.");
            }

            var filter = Expression.Lambda<Func<T, bool>>(
                filterExpression,
                parameter);

            this._query = this._query.Where(filter);

            return this;
        }

        /// <summary>
        /// Sorts the data in ascending order by a specified property.
        /// </summary>
        /// <typeparam name="TKey">The type of the sorting key.</typeparam>
        /// <param name="property">The property expression to sort by.</param>
        /// <returns>The current query builder instance.</returns>
        public QueryBuilder<T> SortBy<TKey>(Expression<Func<T, TKey>> property)
        {
            this._query = this._query.OrderBy(property);
            return this;
        }

        /// <summary>
        /// Performs a secondary sort in ascending order. Must be called after SortBy.
        /// </summary>
        /// <typeparam name="TKey">The type of the sorting key.</typeparam>
        /// <param name="property">The property expression to sort by.</param>
        /// <returns>The current query builder instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if called before a primary sort.</exception>
        public QueryBuilder<T> ThenBy<TKey>(Expression<Func<T, TKey>> property)
        {
            if (this._query is not IOrderedQueryable<T> orderedQuery)
            {
                throw new InvalidOperationException("ThenBy must be used after SortBy.");
            }

            this._query = orderedQuery.ThenBy(property);
            return this;
        }

        /// <summary>
        /// Joins the current data source with another collection based on matching keys.
        /// </summary>
        /// <typeparam name="TOther">The type of elements in the other collection.</typeparam>
        /// <typeparam name="TKey">The type of the join key.</typeparam>
        /// <typeparam name="TResult">The type of the final joined result elements.</typeparam>
        /// <param name="data">The other collection to join with.</param>
        /// <param name="outerKey">The key selector for the current collection.</param>
        /// <param name="innerKey">The key selector for the other collection.</param>
        /// <param name="resultSelector">The expression that projects the combined result.</param>
        /// <returns>A new query builder instance for the joined result type.</returns>
        public QueryBuilder<TResult> Join<TOther, TKey, TResult>(
            IEnumerable<TOther> data,
            Expression<Func<T, TKey>> outerKey,
            Expression<Func<TOther, TKey>> innerKey,
            Expression<Func<T, TOther, TResult>> resultSelector)
        {
            var result = this._query.Join(
                data.AsQueryable(),
                outerKey,
                innerKey,
                resultSelector);

            return new QueryBuilder<TResult>(result);
        }

        /// <summary>
        /// Executes the built query and returns the results as a list.
        /// </summary>
        /// <returns>A list of elements matching the query criteria.</returns>
        public List<T> Execute()
        {
            return this._query.ToList();
        }
    }
}