namespace MarsRoverTrioPrograming
{
    public static class CommandFactory
    {
        private const char MoveCommand = 'M';
        private const char TurnLeftCommand = 'L';

        public static ICommand GenerateCommandFromText(char charCommand, Position position)
        {
            if (charCommand == MoveCommand)
            {
                return new MoveCommand(position);
            }

            if (charCommand == TurnLeftCommand)
            {
                return new TurnLeftCommand(position);
            }

            return new TurnRightCommand(position);
        }
    }
}   