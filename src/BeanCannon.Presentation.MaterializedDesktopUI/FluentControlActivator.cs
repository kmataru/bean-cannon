using BeanCannon.BusinessLogic.Core.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
	class FluentControlActivator
	{
		static Dictionary<AttackMethod, List<Data>> Actions { get; } = new Dictionary<AttackMethod, List<Data>>();

		AttackMethod Name { get; }

		public FluentControlActivator(AttackMethod name)
		{
			if (Actions.ContainsKey(name))
			{
				throw new Exception($"Key already exists in {nameof(FluentControlActivator)}.");
			}

			Name = name;
			Actions.Add(name, new List<Data>());
		}

		public FluentControlActivator Enable(Control control)
		{
			Actions[Name].Add(new Data(Switch.Enable, control));

			return this;
		}

		public FluentControlActivator Disable(Control control)
		{
			Actions[Name].Add(new Data(Switch.Disable, control));

			return this;
		}

		public FluentControlActivator Check(RadioButton radioButton)
		{
			Actions[Name].Add(new Data(Switch.Check, radioButton));

			return this;
		}

		public static void Set(AttackMethod name, bool state)
		{
			if (state)
			{
				Activate(name);
			}
			else
			{
				Deactivate(name);
			}
		}

		public static void Activate(AttackMethod name)
		{
			if (!Actions.ContainsKey(name))
			{
				throw new Exception($"Key {name} does not exist in {nameof(FluentControlActivator)}.");
			}

			var actions = Actions[name];
			foreach (var action in actions)
			{
				if (action.Switch == Switch.Enable)
				{
					action.Control.Enabled = true;
				}
				else if (action.Switch == Switch.Disable)
				{
					action.Control.Enabled = false;
				}
				else
				{
					(action.Control as RadioButton).Checked = true;
				}
			}
		}

		public static void Deactivate(AttackMethod name)
		{
			if (!Actions.ContainsKey(name))
			{
				throw new Exception($"Key {name} does not exist in {nameof(FluentControlActivator)}.");
			}

			var actions = Actions[name];
			foreach (var action in actions)
			{
				if (action.Switch == Switch.Enable)
				{
					action.Control.Enabled = false;
				}
				else
				{
					action.Control.Enabled = true;
				}
			}
		}

		enum Switch
		{
			Enable,
			Disable,
			Check,
		}

		struct Data
		{
			public Data(Switch @switch, Control control)
			{
				Switch = @switch;
				Control = control;
			}

			public Switch Switch { get; }
			public Control Control { get; }
		}
	}
}
