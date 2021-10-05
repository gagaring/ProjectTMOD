using NSubstitute;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VEngine.SO.Variables;
using VEngine.GUI;
using VEngine.GUI.Draggable;
using VEngine.GUI.Split;
using VEngine.Inventory;
using VEngine.Inventory.GUI;
using VEngine.Items;

namespace VTest.Inventory.GUI
{
    public class InventoryGUITestBuilder
    {
        List<GameObject> gos = new List<GameObject>();
        List<Item> items = new List<Item>();
        List<SlotsGUIBehaviourContainer> slotsList = new List<SlotsGUIBehaviourContainer>();
        private List<Item> _items = new List<Item>();

        public static InventoryGUITestBuilder Create()
        {
            return new InventoryGUITestBuilder();
        }

        public InventoryGUITestBuilder CreateItemGUI(out InventoryItemGUI itemGUI, out Image avatarImage, out FloatReference dragPressWindowTime, out RectTransform rectTransform, out BoolReference isDragEnabledRef, bool isDragEnabled = true)
        {
            var go = new GameObject("ItemGUI");
            avatarImage = go.AddComponent<Image>();
            dragPressWindowTime = new FloatReference();
            dragPressWindowTime.Init(0.1f);
            rectTransform = go.GetComponent<RectTransform>();
            isDragEnabledRef = new BoolReference();
            isDragEnabledRef.Init(isDragEnabled);
            var data = new ItemGUIData(PointerEventData.InputButton.Left, isDragEnabledRef, dragPressWindowTime);
            var comp = new ItemGUIComponents(avatarImage, rectTransform);
            itemGUI = new InventoryItemGUI(data, comp);
            gos.Add(go);
            return this;
        }

        public InventoryGUITestBuilder SetItemFakes(ref IInventoryItemGUI itemGUI, out IItem item, out ISlotGUI slotGUI)
        {
            item = Substitute.For<IItem>();
            var details = Substitute.For<IDetails>();
            item.Details.Returns(details);
            slotGUI = Substitute.For<ISlotGUI>();
            itemGUI.Item = item;
            itemGUI.SetSlot(slotGUI);
            return this;
        }

        public InventoryGUITestBuilder CreateFakesAttributesForItemGUI(out IItem item)
        {
            item = Substitute.For<IItem>();
            var details = Substitute.For<IDetails>();
            item.Details.Returns(details);
            var inventoryDetails = ScriptableObject.CreateInstance<InventoryItemComponent>();
            var guiDetails = ScriptableObject.CreateInstance<InventoryGUIItemComponent>();
            item.Find(typeof(InventoryItemComponent)).Returns(inventoryDetails);
            item.Find(typeof(InventoryGUIItemComponent)).Returns(guiDetails);
            return this;
        }

        public InventoryGUITestBuilder CreateSlotGUI(out SlotGUI slotGUI, int slotIndex, IInventoryGUIModifier inventoryGUIModifier, InventoryItemGUI itemGUI, out RectTransform rectTransform, out Image backgroundImage, out TMP_Text amountText, out ISlotGUISprites spriteRef)
        {
            var go = new GameObject("SlotGUI");
            rectTransform = go.AddComponent<RectTransform>();
            backgroundImage = go.AddComponent<Image>();
            amountText = new GameObject("AmountText").AddComponent<TextMeshProUGUI>();
            amountText.transform.SetParent(go.transform);
            spriteRef = Substitute.For<ISlotGUISprites>();
            var slotData = new SlotData(slotIndex, spriteRef);
            var slotCompontents = new SlotCompontents(rectTransform, inventoryGUIModifier, itemGUI, amountText.gameObject, amountText, backgroundImage);
            slotGUI = new SlotGUI(slotData, slotCompontents);
            gos.Add(go);
            return this;
        }

		public class SlotData : SlotGUI.ISlotData
		{
            private ISlotGUISprites _slotGUISprites;

            public SlotData(int slotIndex, ISlotGUISprites slotGUISprites)
			{
                SlotIndex = slotIndex;
                _slotGUISprites = slotGUISprites;
            }

            public int SlotIndex { get; set; }
            public Sprite AvailableSprite { get => _slotGUISprites.AvailableSprite; }
            public Sprite UnavailableSprite { get => _slotGUISprites.UnavailableSprite; }
        }

		public class SlotCompontents : SlotGUI.ISlotComponents
        {
            public DropSlot.IDropSlotComponents DropSlotComponents { get; set; }
            public IInventoryGUIModifier InventoryGUIModifier { get; set; }
            public InventoryItemGUI ItemGUI { get; set; }
            public GameObject AmountTextHolder { get; set; }
            public TMP_Text AmountText { get; set; }
            public Image BackgroundImage { get; set; }

			public ISelection Selection { get; set; }

			public SlotCompontents(RectTransform rectTransform, IInventoryGUIModifier inventoryGUIModifier, InventoryItemGUI itemGUI, GameObject amountTextHolder, TMP_Text amountText, Image backgroundImage)
			{
                DropSlotComponents = new DropSlotComponents(rectTransform);
                InventoryGUIModifier = inventoryGUIModifier;
                ItemGUI = itemGUI;
                AmountTextHolder = amountTextHolder;
                AmountText = amountText;
                BackgroundImage = backgroundImage;
            }
		}

		public class DropSlotComponents : DropSlot.IDropSlotComponents
		{
            private RectTransform _rectTransform;

            public DropSlotComponents(RectTransform rectTransform)
			{
                _rectTransform = rectTransform;
			}
			public Vector2 Position => _rectTransform.position;
		}

        public InventoryGUITestBuilder CreateItem(uint amount = 1)
        {
            for (uint i = 0; i < amount; ++i)
            {
                var item = ScriptableObject.CreateInstance<Item>();
                item.name = $"Item{i}";
                item.Details = new Details();

                var inventoryItemComponents = ScriptableObject.CreateInstance<InventoryItemComponent>();
                var inventoryGUIItemComponent = ScriptableObject.CreateInstance<InventoryGUIItemComponent>();
                
                inventoryItemComponents.StackCount = 1;

                item.AddComponent(inventoryItemComponents);
                item.AddComponent(inventoryGUIItemComponent);

                _items.Add(item);
            }
            return this;
        }

        public Item GetItem(int index = 0) => _items[index];

        public InventoryGUITestBuilder CreateInventoryGUIBuilder(out IInventoryGUIBuilder inventoryGUIBuilder, out Transform normalParent, out DragParentSO dragParent)
        {
            var slotGUI = CreateSlotGUIBehaviour();
            inventoryGUIBuilder = new VEngine.Inventory.GUI.InventoryGUIBuilder(slotGUI);
            normalParent = new GameObject("normalParent").transform;
            dragParent = ScriptableObject.CreateInstance<DragParentSO>();
            dragParent.Value = new GameObject("dragParent").transform;
            gos.Add(normalParent.gameObject);
            gos.Add(dragParent.Value.gameObject);
            gos.Add(slotGUI.gameObject);
            return this;
        }

        private SlotGUIBehaviour CreateSlotGUIBehaviour()
        {
            var gameObject = new GameObject("SlotGUIBehavoiur");
            gameObject.AddComponent<Image>();
            //go.AddComponent<RectTransform>();
            var itemGUI = CreateItemGUIBehaviour();
            itemGUI.transform.SetParent(gameObject.transform);

            var amountText = new GameObject("AmountText").AddComponent<TextMeshProUGUI>();
            amountText.transform.SetParent(gameObject.transform);

            var slotGUIBehavoiur = gameObject.AddComponent<SlotGUIBehaviour>();

            gos.Add(slotGUIBehavoiur.gameObject);
            gos.Add(amountText.gameObject);
            return slotGUIBehavoiur;
        }

        private InventoryItemGUIBehaviour CreateItemGUIBehaviour()
		{
            var gameObject = new GameObject("ItemGUI");
            gameObject.gameObject.AddComponent<RectTransform>();
            //itemGUI.gameObject.AddComponent<CanvasGroup>();
            gameObject.gameObject.AddComponent<Image>();
            var itemGUI = gameObject.AddComponent<InventoryItemGUIBehaviour>();
            gos.Add(itemGUI.gameObject);
            return itemGUI;
        }

        public InventoryGUITestBuilder CreateInventoryGUI(out InventoryGUI inventoryGUI, out IInventoryGUIBuilder fakeBuilder, out IInventory fakeInventory, out GameObject parent)
        {
            fakeBuilder = Substitute.For<IInventoryGUIBuilder>();
            CreateFakeInventory(out fakeInventory);
            parent = new GameObject("InventoryParent");

            InventoryGUIBase.IInventoryGUIData data = Substitute.For<InventoryGUIBase.IInventoryGUIData>();
            data.Builder.Returns(fakeBuilder);
            data.Inventory.Returns(fakeInventory);
            data.Main.Returns(parent);

            inventoryGUI = new InventoryGUI(data);
            gos.Add(parent);
            return this;
        }

        public InventoryGUITestBuilder CreateInventoryGUIWithSplit(out InventoryGUIWithSplit inventoryGUI, out IInventoryGUIBuilder fakeBuilder, out IInventory fakeInventory, out GameObject parent, out IReferenceWithConstant<bool, BoolVariable> splitModifier, out ISplitSlider splitSlider)
        {
            fakeBuilder = Substitute.For<IInventoryGUIBuilder>();
            CreateFakeInventory(out fakeInventory);
            parent = new GameObject("InventoryParent");

            splitModifier = Substitute.For<IReferenceWithConstant<bool, BoolVariable>>();

            var splitSliderReference = Substitute.For<ISplitSliderReference>();
            splitSlider = Substitute.For<ISplitSlider>();
            splitSliderReference.Value.Returns(splitSlider);


            InventoryGUIWithSplit.IInventorySplitData data = Substitute.For<InventoryGUIWithSplit.IInventorySplitData>();
            data.Builder.Returns(fakeBuilder);
            data.Inventory.Returns(fakeInventory);
            data.SplitModifier.Returns(splitModifier);
            data.SplitSlider.Returns(splitSliderReference);
            data.Main.Returns(parent);

            inventoryGUI = new InventoryGUIWithSplit(data);
            gos.Add(parent);
            return this;
        }

		private void CreateFakeInventory(out IInventory fakeInventory)
        {
            fakeInventory = Substitute.For<IInventory>();
            fakeInventory.Data.Returns(Substitute.For<IInventoryData>());
            fakeInventory.Service.Returns(Substitute.For<IInventoryService>());
        }

		public InventoryGUITestBuilder CreateSlotGUIContanier(out SlotsGUIBehaviourContainer slots)
        {
            slots = ScriptableObject.CreateInstance<SlotsGUIBehaviourContainer>();
            slotsList.Add(slots);
            return this;
        }

        public void Destroy()
        {
            foreach (var curr in gos)
                Object.DestroyImmediate(curr);
            foreach (var curr in items)
                Object.DestroyImmediate(curr);
            foreach (var curr in slotsList)
                Object.DestroyImmediate(curr);
            foreach (var curr in _items)
                Object.DestroyImmediate(curr);
        }


        protected class ItemGUIData : InventoryItemGUI.IItemGUIData
        {
            public DraggableButton.IDraggableData DraggableData { get; set; }

			public ItemGUIData(PointerEventData.InputButton dragButton, BoolReference isDragEnabledRef, FloatReference dragPressWindowTime)
			{
                DraggableData = new DraggableData(dragButton, isDragEnabledRef, dragPressWindowTime);
            }
        }

        protected class ItemGUIComponents : InventoryItemGUI.IItemGUIComponents
        {
            public DraggableButton.IDraggableComponents DraggableComponents { get; set; }
            public Image Avatar { get; set; }

			public ISelection Selection { get; private set; }

			public ItemGUIComponents(Image avatar, RectTransform rect)
            {
                DraggableComponents = new DraggableComponents(rect, new DraggableOnClickEvents());
                Avatar = avatar;
                Selection = Substitute.For<ISelection>();
            }
		}

        protected class DraggableData : DraggableButton.IDraggableData
        {
            BoolReference _isDragEnabledRef; 
            FloatReference _dragPressWindowTime;
            public PointerEventData.InputButton DragButton { get; set; }
            public bool IsDragEnabled { get => _isDragEnabledRef.Value; }
            public float DragPressWindowTime { get => _dragPressWindowTime.Value; }

            public DraggableData(PointerEventData.InputButton dragButton, BoolReference isDragEnabledRef, FloatReference dragPressWindowTime)
            {
                DragButton = dragButton;
                _isDragEnabledRef = isDragEnabledRef;
                _dragPressWindowTime = dragPressWindowTime;
            }
        }

        protected class DraggableComponents : DraggableButton.IDraggableComponents
        {
            public RectTransform RectTransform { get; set; }
            public IClickEvents ClickEvents { get; set; }

            public DraggableComponents(RectTransform rect, DraggableOnClickEvents clickEvents)
            {
                RectTransform = rect;
                ClickEvents = clickEvents;
            }
        }

        protected class DraggableOnClickEvents : IClickEvents
        {
            public UnityEvent OnLeftClicked { get; set; }
            public UnityEvent OnRightClicked { get; set; }
            public UnityEvent OnMiddleClicked { get; set; }

            public DraggableOnClickEvents()
            {
                OnLeftClicked = new UnityEvent();
                OnRightClicked = new UnityEvent();
                OnMiddleClicked = new UnityEvent();
            }
        }
    }
}
