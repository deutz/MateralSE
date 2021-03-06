﻿namespace VRage.Game.VisualScripting.Missions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using VRage.Game.VisualScripting;
    using VRage.Generics;
    using VRage.Generics.StateMachine;
    using VRage.Utils;

    public class MyVSStateMachineNode : MyStateMachineNode
    {
        private readonly Type m_scriptType;
        private IMyStateMachineScript m_instance;
        private readonly Dictionary<MyStringId, IMyVariableStorage<bool>> m_transitionNamesToVariableStorages;

        public MyVSStateMachineNode(string name, Type script) : base(name)
        {
            this.m_transitionNamesToVariableStorages = new Dictionary<MyStringId, IMyVariableStorage<bool>>();
            this.m_scriptType = script;
        }

        public void ActivateScript(bool restored = false)
        {
            if ((this.m_scriptType != null) && (this.m_instance == null))
            {
                this.m_instance = Activator.CreateInstance(this.m_scriptType) as IMyStateMachineScript;
                if (restored)
                {
                    this.m_instance.Deserialize();
                }
                this.m_instance.Init();
                using (Dictionary<MyStringId, IMyVariableStorage<bool>>.ValueCollection.Enumerator enumerator = this.m_transitionNamesToVariableStorages.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.SetValue(MyStringId.GetOrCompute("Left"), false);
                    }
                }
            }
        }

        public void DisposeScript()
        {
            if (this.m_instance != null)
            {
                this.m_instance.Dispose();
                this.m_instance = null;
            }
        }

        public override void OnUpdate(MyStateMachine stateMachine)
        {
            if (this.m_instance == null)
            {
                using (Dictionary<MyStringId, IMyVariableStorage<bool>>.ValueCollection.Enumerator enumerator = this.m_transitionNamesToVariableStorages.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        enumerator.Current.SetValue(MyStringId.GetOrCompute("Left"), true);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.m_instance.TransitionTo))
                {
                    this.m_instance.Update();
                }
                if (!string.IsNullOrEmpty(this.m_instance.TransitionTo))
                {
                    if (base.OutTransitions.Count == 0)
                    {
                        HashSet<MyStateMachineCursor>.Enumerator enumerator = base.Cursors.GetEnumerator();
                        enumerator.MoveNext();
                        MyStateMachineCursor current = enumerator.Current;
                        stateMachine.DeleteCursor(current.Id);
                    }
                    else
                    {
                        IMyVariableStorage<bool> storage;
                        MyStringId orCompute = MyStringId.GetOrCompute(this.m_instance.TransitionTo);
                        using (List<MyStateMachineTransition>.Enumerator enumerator3 = base.OutTransitions.GetEnumerator())
                        {
                            while (enumerator3.MoveNext() && !(enumerator3.Current.Name == orCompute))
                            {
                            }
                        }
                        if (this.m_transitionNamesToVariableStorages.TryGetValue(MyStringId.GetOrCompute(this.m_instance.TransitionTo), out storage))
                        {
                            storage.SetValue(MyStringId.GetOrCompute("Left"), true);
                        }
                    }
                }
            }
        }

        protected override void TransitionAddedInternal(MyStateMachineTransition transition)
        {
            base.TransitionAddedInternal(transition);
            if (!ReferenceEquals(transition.TargetNode, this))
            {
                VSNodeVariableStorage storage = new VSNodeVariableStorage();
                transition.Conditions.Add(new MyCondition<bool>(storage, MyCondition<bool>.MyOperation.Equal, "Left", "Right"));
                this.m_transitionNamesToVariableStorages.Add(transition.Name, storage);
            }
        }

        public IMyStateMachineScript ScriptInstance =>
            this.m_instance;

        private class VSNodeVariableStorage : IMyVariableStorage<bool>
        {
            private MyStringId left = MyStringId.GetOrCompute("Left");
            private MyStringId right = MyStringId.GetOrCompute("Right");
            private bool m_leftValue;
            private bool m_rightvalue = true;

            public bool GetValue(MyStringId key, out bool value)
            {
                value = false;
                if (key == this.left)
                {
                    value = this.m_leftValue;
                }
                if (key == this.right)
                {
                    value = this.m_rightvalue;
                }
                return true;
            }

            public void SetValue(MyStringId key, bool newValue)
            {
                if (key == this.left)
                {
                    this.m_leftValue = newValue;
                }
                if (key == this.right)
                {
                    this.m_rightvalue = newValue;
                }
            }
        }
    }
}

