# ⚡ Alfano Tech Portfolio & Miner Control Center (MCC)

> **"Software shouldn't just display data; it should control the physical world."**

### 🔗 Live System: [https://titanalfapro.org](https://titanalfapro.org)

---

## 📖 Executive Summary
This repository houses the full source code for two production-grade engineering projects:
1.  **The Miner Control Center (MCC):** A desktop telemetry engine designed for high-frequency ASIC hardware management.
2.  **Full-Stack Cloud Portfolio:** A cloud-native .NET 8 web application orchestrated via Terraform.

**Status Update:** After successfully troubleshooting a critical SQL connectivity blockage ("Error 40"), the cloud portfolio was successfully deployed and is now **active and live at [titanalfapro.org](https://titanalfapro.org)**.

---

## 🏗️ Architecture Diagram
The diagram below illustrates the dual-nature of this repository. It visualizes how the **MCC** bypasses HTTP to speak raw TCP to hardware, and how the **Web Portfolio** utilizes a secure Ngrok tunnel to bridge local development with enterprise Azure resources.

```mermaid
graph TD
    %% --- COLOR DEFINITIONS (Senior Architect Style) ---
    classDef external fill:#e3f2fd,stroke:#1565c0,stroke-width:2px,color:#0d47a1;
    classDef hardware fill:#fff9c4,stroke:#fbc02d,stroke-width:2px,color:#e65100;
    classDef app fill:#e8f5e9,stroke:#2e7d32,stroke-width:2px,color:#1b5e20;
    classDef cloud fill:#f3e5f5,stroke:#7b1fa2,stroke-width:2px,color:#4a148c;
    classDef data fill:#efebe9,stroke:#5d4037,stroke-width:2px,color:#3e2723;

    %% --- PHYSICAL LAYER (Hardware) ---
    subgraph "Mining Farm (Physical Layer)"
        Whatsminer["⚒️ Whatsminer ASIC"]:::hardware
        Antminer["⚒️ Antminer ASIC"]:::hardware
    end

    %% --- DESKTOP CONTROL LAYER ---
    subgraph "Miner Control Center (MCC)"
        DesktopApp["🖥️ MCC Desktop Engine (C# .NET)"]:::app
        TCPSocket["🔌 Raw TCP Socket (Port 4028)"]:::app
        Regex["🧠 Regex Parser Engine"]:::app
        SafetyLoop["🛡️ Thermal Safety Watchdog"]:::app
    end

    %% --- WEB INFRASTRUCTURE LAYER ---
    subgraph "Cloud Portfolio Infrastructure"
        WebApp["🌐 .NET 8 Web Portfolio"]:::cloud
        Ngrok["🔒 Ngrok Secure Tunnel"]:::cloud
        AzureSQL[("☁️ Azure SQL Database")]:::data
    end

    %% --- LOGIC FLOWS ---
    %% 1. MCC Control Loop
    DesktopApp --"Injects JSON-RPC"--> TCPSocket
    TCPSocket --"Polls Telemetry (500ms)"--> Whatsminer
    TCPSocket --"Polls Telemetry (500ms)"--> Antminer
    
    %% 2. Parsing & Safety
    Whatsminer --"Raw Firmware Data"--> Regex
    Antminer --"Raw Firmware Data"--> Regex
    Regex --"Structured Telemetry"--> SafetyLoop
    SafetyLoop --"Kill Command (>85°C)"--> TCPSocket

    %% 3. Web & Cloud Data
    WebApp --"Entity Framework Core"--> Ngrok
    Ngrok --"Bypasses Firewall (Error 40)"--> AzureSQL
    WebApp --"Deploys To"--> LiveSite["🌍 titanalfapro.org"]:::external

    %% --- APPLY STYLES ---
    class Whatsminer,Antminer hardware;
    class AzureSQL data;
