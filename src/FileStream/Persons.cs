namespace FileHandling
{
    /// <summary>
    /// Users logging
    /// </summary>
    internal class Persons
    {
        private readonly Logger _logger = new Logger("log.txt");
        private string _firstPersonName = "First Person";
        private string _secondPersonName = "Second Person";
        private string _thirdPersonName = "Third Person";
        private string _fourthPersonName = "Fourth Person";

        /// <summary>
        /// Runs multiple user log at same time
        /// </summary>
        /// <returns>>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Run()
        {
            Task logFirstPerson = this._logger.LogInformation(this._firstPersonName);
            Task logSecondPerson = this._logger.LogWarning(this._secondPersonName);
            Task logThirdPerson = this._logger.LogError(this._thirdPersonName);
            Task logFourthPerson = this._logger.LogInformation(this._fourthPersonName);
            await Task.WhenAll(logFirstPerson, logSecondPerson, logThirdPerson, logFourthPerson);
        }
    }
}
