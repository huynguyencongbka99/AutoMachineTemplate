AutoMachine
│
├── Core
│   ├── Enums
│   │   └── MachineAction
│   └── Controllers
│       └── AutoController
│
├── Application
│   └── Services
│       └── UIService
│
├── Infrastructure
│   └── PLC
│       └── PLC
│
├── Presentation
│   └── WinForms
│       ├── MainForm
│       └── Forms
│           └── ErrorForm
│
└── Program


UI (Presentation)
   ↓
UIService (Application)
   ↓
AutoController (Core)
   ↓
PLC (Infrastructure)

Code này đã:

✅ Tách layer đúng chuẩn
✅ Không block thread
✅ Có timeout thực tế
✅ Có PLC hook
✅ Ready để scale multi-station

Nhưng vẫn có thể cải thiện:

👉 new Thread(async () => ...) chưa “đẹp chuẩn .NET”
→ sau này nên chuyển sang:

Task.Run
hoặc loop sync + await pattern