using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace measure
{
    class Command_line
    {
        public void add_command(int index, Command command)
        {
            if (index + 1 > m_command.Length)
                Array.Resize(ref m_command, index + 1);
            this.m_command[index] = command;
        }

        public void clear()
        {
            Array.Clear(m_command, 0, m_command.Length);
        }

        public List<List<String>> get_command_string()
        {
            List<List<String>> result = new List<List<String>>();
            foreach (Command command in m_command)
            {
                if (command != null)
                    result.Add(command.get_command_string());
            }
            return result;
        }

        private Command[] m_command = new Command[1];
    }
}
