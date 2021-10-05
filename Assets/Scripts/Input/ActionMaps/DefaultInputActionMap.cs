// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Input/ActionMap/DefaultInputActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace VEngine.Input
{
    public class @DefaultInputActionMap : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DefaultInputActionMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInputActionMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5c0bc91b-17ef-4682-9383-24ab4779815e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2e01799b-6591-47a7-b54d-c811d126f620"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""ecae842f-1c39-4600-9e81-8f316761a18c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""2e3ccbf1-8edf-4390-8c50-faef969287a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""65142915-6ae5-4855-a2c2-3099c1335805"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6b172c14-7091-4132-a197-7a4219e1e9d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""63956c54-2f44-4942-938c-29741adc90be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""9585948c-b198-4caa-bd2a-bb861b880d3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f36ca7d6-c24c-4e97-991f-4cdf1e02a699"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandSlot0"",
                    ""type"": ""Button"",
                    ""id"": ""1d1d0402-0a16-4c15-b74a-50eea6247cfe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandSlot1"",
                    ""type"": ""Button"",
                    ""id"": ""fed74f87-5e74-4584-adde-0d20aa3498f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseHand"",
                    ""type"": ""Button"",
                    ""id"": ""461934fc-4838-43f2-a1f2-9c3ad53dc298"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TargetingHand"",
                    ""type"": ""Button"",
                    ""id"": ""d1087c44-c031-46a4-9a64-34e1a32e8c80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Loot"",
                    ""type"": ""Button"",
                    ""id"": ""7859876a-ab6d-479e-a1ee-8c273c2ba33f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""13be7852-c20e-4d36-a583-9958b0c80643"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8c0c81f-5e47-4321-aa6b-419bb58de5c5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""052b94ec-b548-40ec-b4b8-5a3506df8552"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d44b753c-0782-4897-89ef-1361cbf1fb88"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8f5409c-ad2a-4a98-89ef-317d99c781cf"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc8dadf3-004e-435e-93b2-b94963ccfb4f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""02b0d8b5-a924-4ccf-ad92-8630dbfb5bc4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5ce2e896-1119-4227-a647-7060d92f29b2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""16f5add8-003a-465f-972c-5bb4fa437f6c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""abbd2e56-e963-44f5-8c5f-6f9fc10cf29c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eedd60cd-cddb-4722-8826-011b38857009"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""39c9f525-79cf-417f-873a-3cbd50e6892c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21caa0f8-3474-4407-98cc-79c7c7d7f526"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""accb2332-6ba7-49ab-ab66-954fae795ffe"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a72aaeeb-df8f-46a4-bf4c-3b1a376d729b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7615149c-a99e-4ac2-9458-5e1dfe698fd7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f7c1cf2-6594-47e4-a079-9daf44752f83"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c7ab06-b718-4bd8-892f-daed5cdf7685"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandSlot0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4159b75-bc11-4a36-b2eb-07a224096fdb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandSlot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87b7c650-e01f-4319-9163-98a6da1499b3"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33e0557f-c258-45c1-9d6b-53663093be6b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TargetingHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bb1b3a5-c40e-4543-a7e4-172ce095cda8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Loot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inspector"",
            ""id"": ""100da584-3655-4aae-a065-b8d4665d426d"",
            ""actions"": [
                {
                    ""name"": ""RotateX"",
                    ""type"": ""Value"",
                    ""id"": ""ce1e2c6c-fcaf-4308-95ab-2275f0d47dae"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateY"",
                    ""type"": ""Value"",
                    ""id"": ""73e0afdc-6b08-432a-8086-fc0c7207fccd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7a0bb2c0-d268-4b75-8fe4-a36b05477332"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb663237-3b39-4768-a93b-60f7d6001074"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""115576e3-c7d1-447b-a987-6209a81eae50"",
            ""actions"": [
                {
                    ""name"": ""Split"",
                    ""type"": ""Button"",
                    ""id"": ""09be5e5f-b6de-4086-b757-87bcec6c99a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5ba5436-2411-47cf-abd4-475c70795845"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Split"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48206f09-c737-4ca2-b80f-7a5e851944e5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Split"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interact"",
            ""id"": ""9b69aca5-b0de-4482-acdb-e754808c0167"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""6c7b179e-78ea-4447-ba62-ef63cdaec42f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""64f89c64-2193-4ac6-96f1-65f410e3550d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7d385403-78ba-443f-8b6b-2e6ce59e34b3"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f610b266-6b30-417f-bb45-a81133bd6192"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2bbf9b40-828f-4075-b74c-1c1af15530be"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b5313454-9978-4b96-b30c-4951a916e0a2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""924f5f4f-d5a3-41fa-9b4a-bbb9dd35d89b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a459ad15-201b-4023-962d-f5df8554d662"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMenu"",
            ""id"": ""67f7f655-9919-4515-b0b9-e3c5b5ffd7d9"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""Global"",
            ""id"": ""d0f563d0-f0d0-48aa-a064-61435f0568af"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""dc5aae6e-7c78-49fc-89d0-f41bb2de1f07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TogglePlayerMenu"",
                    ""type"": ""Button"",
                    ""id"": ""dce020e7-b732-4385-b241-5cb113705977"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fade2dd-5b26-4386-b5e9-30f939781e1c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49894688-d464-453c-abf1-4288d2dd7756"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef6590ca-1434-4a66-9d06-20ecd162ce2c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePlayerMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c2e60d3-a832-47fc-b861-d9ee5102f61b"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePlayerMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
            m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
            m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
            m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
            m_Player_HandSlot0 = m_Player.FindAction("HandSlot0", throwIfNotFound: true);
            m_Player_HandSlot1 = m_Player.FindAction("HandSlot1", throwIfNotFound: true);
            m_Player_UseHand = m_Player.FindAction("UseHand", throwIfNotFound: true);
            m_Player_TargetingHand = m_Player.FindAction("TargetingHand", throwIfNotFound: true);
            m_Player_Loot = m_Player.FindAction("Loot", throwIfNotFound: true);
            // Inspector
            m_Inspector = asset.FindActionMap("Inspector", throwIfNotFound: true);
            m_Inspector_RotateX = m_Inspector.FindAction("RotateX", throwIfNotFound: true);
            m_Inspector_RotateY = m_Inspector.FindAction("RotateY", throwIfNotFound: true);
            // Inventory
            m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
            m_Inventory_Split = m_Inventory.FindAction("Split", throwIfNotFound: true);
            // Interact
            m_Interact = asset.FindActionMap("Interact", throwIfNotFound: true);
            m_Interact_Rotate = m_Interact.FindAction("Rotate", throwIfNotFound: true);
            m_Interact_Close = m_Interact.FindAction("Close", throwIfNotFound: true);
            // PlayerMenu
            m_PlayerMenu = asset.FindActionMap("PlayerMenu", throwIfNotFound: true);
            // Global
            m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
            m_Global_Close = m_Global.FindAction("Close", throwIfNotFound: true);
            m_Global_TogglePlayerMenu = m_Global.FindAction("TogglePlayerMenu", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Rotate;
        private readonly InputAction m_Player_Crouch;
        private readonly InputAction m_Player_Sprint;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_MousePosition;
        private readonly InputAction m_Player_Pause;
        private readonly InputAction m_Player_HandSlot0;
        private readonly InputAction m_Player_HandSlot1;
        private readonly InputAction m_Player_UseHand;
        private readonly InputAction m_Player_TargetingHand;
        private readonly InputAction m_Player_Loot;
        public struct PlayerActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public PlayerActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
            public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
            public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
            public InputAction @Pause => m_Wrapper.m_Player_Pause;
            public InputAction @HandSlot0 => m_Wrapper.m_Player_HandSlot0;
            public InputAction @HandSlot1 => m_Wrapper.m_Player_HandSlot1;
            public InputAction @UseHand => m_Wrapper.m_Player_UseHand;
            public InputAction @TargetingHand => m_Wrapper.m_Player_TargetingHand;
            public InputAction @Loot => m_Wrapper.m_Player_Loot;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                    @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                    @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                    @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                    @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                    @HandSlot0.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot0;
                    @HandSlot0.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot0;
                    @HandSlot0.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot0;
                    @HandSlot1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot1;
                    @HandSlot1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot1;
                    @HandSlot1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandSlot1;
                    @UseHand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseHand;
                    @UseHand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseHand;
                    @UseHand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseHand;
                    @TargetingHand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTargetingHand;
                    @TargetingHand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTargetingHand;
                    @TargetingHand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTargetingHand;
                    @Loot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoot;
                    @Loot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoot;
                    @Loot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoot;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @HandSlot0.started += instance.OnHandSlot0;
                    @HandSlot0.performed += instance.OnHandSlot0;
                    @HandSlot0.canceled += instance.OnHandSlot0;
                    @HandSlot1.started += instance.OnHandSlot1;
                    @HandSlot1.performed += instance.OnHandSlot1;
                    @HandSlot1.canceled += instance.OnHandSlot1;
                    @UseHand.started += instance.OnUseHand;
                    @UseHand.performed += instance.OnUseHand;
                    @UseHand.canceled += instance.OnUseHand;
                    @TargetingHand.started += instance.OnTargetingHand;
                    @TargetingHand.performed += instance.OnTargetingHand;
                    @TargetingHand.canceled += instance.OnTargetingHand;
                    @Loot.started += instance.OnLoot;
                    @Loot.performed += instance.OnLoot;
                    @Loot.canceled += instance.OnLoot;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Inspector
        private readonly InputActionMap m_Inspector;
        private IInspectorActions m_InspectorActionsCallbackInterface;
        private readonly InputAction m_Inspector_RotateX;
        private readonly InputAction m_Inspector_RotateY;
        public struct InspectorActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public InspectorActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @RotateX => m_Wrapper.m_Inspector_RotateX;
            public InputAction @RotateY => m_Wrapper.m_Inspector_RotateY;
            public InputActionMap Get() { return m_Wrapper.m_Inspector; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InspectorActions set) { return set.Get(); }
            public void SetCallbacks(IInspectorActions instance)
            {
                if (m_Wrapper.m_InspectorActionsCallbackInterface != null)
                {
                    @RotateX.started -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateX;
                    @RotateX.performed -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateX;
                    @RotateX.canceled -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateX;
                    @RotateY.started -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateY;
                    @RotateY.performed -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateY;
                    @RotateY.canceled -= m_Wrapper.m_InspectorActionsCallbackInterface.OnRotateY;
                }
                m_Wrapper.m_InspectorActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RotateX.started += instance.OnRotateX;
                    @RotateX.performed += instance.OnRotateX;
                    @RotateX.canceled += instance.OnRotateX;
                    @RotateY.started += instance.OnRotateY;
                    @RotateY.performed += instance.OnRotateY;
                    @RotateY.canceled += instance.OnRotateY;
                }
            }
        }
        public InspectorActions @Inspector => new InspectorActions(this);

        // Inventory
        private readonly InputActionMap m_Inventory;
        private IInventoryActions m_InventoryActionsCallbackInterface;
        private readonly InputAction m_Inventory_Split;
        public struct InventoryActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public InventoryActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Split => m_Wrapper.m_Inventory_Split;
            public InputActionMap Get() { return m_Wrapper.m_Inventory; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
            public void SetCallbacks(IInventoryActions instance)
            {
                if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
                {
                    @Split.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                    @Split.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                    @Split.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSplit;
                }
                m_Wrapper.m_InventoryActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Split.started += instance.OnSplit;
                    @Split.performed += instance.OnSplit;
                    @Split.canceled += instance.OnSplit;
                }
            }
        }
        public InventoryActions @Inventory => new InventoryActions(this);

        // Interact
        private readonly InputActionMap m_Interact;
        private IInteractActions m_InteractActionsCallbackInterface;
        private readonly InputAction m_Interact_Rotate;
        private readonly InputAction m_Interact_Close;
        public struct InteractActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public InteractActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotate => m_Wrapper.m_Interact_Rotate;
            public InputAction @Close => m_Wrapper.m_Interact_Close;
            public InputActionMap Get() { return m_Wrapper.m_Interact; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractActions set) { return set.Get(); }
            public void SetCallbacks(IInteractActions instance)
            {
                if (m_Wrapper.m_InteractActionsCallbackInterface != null)
                {
                    @Rotate.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnRotate;
                    @Close.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnClose;
                    @Close.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnClose;
                    @Close.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnClose;
                }
                m_Wrapper.m_InteractActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                    @Close.started += instance.OnClose;
                    @Close.performed += instance.OnClose;
                    @Close.canceled += instance.OnClose;
                }
            }
        }
        public InteractActions @Interact => new InteractActions(this);

        // PlayerMenu
        private readonly InputActionMap m_PlayerMenu;
        private IPlayerMenuActions m_PlayerMenuActionsCallbackInterface;
        public struct PlayerMenuActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public PlayerMenuActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputActionMap Get() { return m_Wrapper.m_PlayerMenu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMenuActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMenuActions instance)
            {
                if (m_Wrapper.m_PlayerMenuActionsCallbackInterface != null)
                {
                }
                m_Wrapper.m_PlayerMenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                }
            }
        }
        public PlayerMenuActions @PlayerMenu => new PlayerMenuActions(this);

        // Global
        private readonly InputActionMap m_Global;
        private IGlobalActions m_GlobalActionsCallbackInterface;
        private readonly InputAction m_Global_Close;
        private readonly InputAction m_Global_TogglePlayerMenu;
        public struct GlobalActions
        {
            private @DefaultInputActionMap m_Wrapper;
            public GlobalActions(@DefaultInputActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Close => m_Wrapper.m_Global_Close;
            public InputAction @TogglePlayerMenu => m_Wrapper.m_Global_TogglePlayerMenu;
            public InputActionMap Get() { return m_Wrapper.m_Global; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
            public void SetCallbacks(IGlobalActions instance)
            {
                if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
                {
                    @Close.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                    @Close.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                    @Close.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnClose;
                    @TogglePlayerMenu.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTogglePlayerMenu;
                    @TogglePlayerMenu.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTogglePlayerMenu;
                    @TogglePlayerMenu.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnTogglePlayerMenu;
                }
                m_Wrapper.m_GlobalActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Close.started += instance.OnClose;
                    @Close.performed += instance.OnClose;
                    @Close.canceled += instance.OnClose;
                    @TogglePlayerMenu.started += instance.OnTogglePlayerMenu;
                    @TogglePlayerMenu.performed += instance.OnTogglePlayerMenu;
                    @TogglePlayerMenu.canceled += instance.OnTogglePlayerMenu;
                }
            }
        }
        public GlobalActions @Global => new GlobalActions(this);
        private int m_PlayerSchemeIndex = -1;
        public InputControlScheme PlayerScheme
        {
            get
            {
                if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
                return asset.controlSchemes[m_PlayerSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnPause(InputAction.CallbackContext context);
            void OnHandSlot0(InputAction.CallbackContext context);
            void OnHandSlot1(InputAction.CallbackContext context);
            void OnUseHand(InputAction.CallbackContext context);
            void OnTargetingHand(InputAction.CallbackContext context);
            void OnLoot(InputAction.CallbackContext context);
        }
        public interface IInspectorActions
        {
            void OnRotateX(InputAction.CallbackContext context);
            void OnRotateY(InputAction.CallbackContext context);
        }
        public interface IInventoryActions
        {
            void OnSplit(InputAction.CallbackContext context);
        }
        public interface IInteractActions
        {
            void OnRotate(InputAction.CallbackContext context);
            void OnClose(InputAction.CallbackContext context);
        }
        public interface IPlayerMenuActions
        {
        }
        public interface IGlobalActions
        {
            void OnClose(InputAction.CallbackContext context);
            void OnTogglePlayerMenu(InputAction.CallbackContext context);
        }
    }
}
