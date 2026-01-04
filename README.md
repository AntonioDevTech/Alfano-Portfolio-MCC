# ⚡ Alfano Tech Portfolio & Miner Control Center (MCC)

> **"Software shouldn't just display data; it should control the physical world."**

### 🔗 Live System: [https://titanalfapro.org](https://titanalfapro.org)

---

## 📖 Executive Summary
This repository contains the source code for two distinct engineering challenges I tackled where I had to bridge the gap between low level hardware control and high level cloud architecture.

First is the **Miner Control Center (MCC)**. I built a desktop telemetry engine designed to manage a mixed fleet of **Whatsminer and Antminer ASICs**. The challenge was that standard web interfaces are too slow for real time monitoring of different brands simultaneously so I had to reverse engineer the hardware protocols to get them all talking to one dashboard.

Second is the **Full-Stack Cloud Portfolio** which is a cloud native web application. I didn't want a basic setup so I used Terraform to automate the infrastructure on Azure and had to engineer a custom tunnel solution to get my local development environment talking to the cloud database securely.

---

## 🏗️ Architecture Diagram
The diagram below illustrates the dual nature of this repository. It visualizes how the MCC bypasses standard HTTP protocols to speak raw TCP directly to both Whatsminer and Antminer hardware, and how the Web Portfolio utilizes a secure Ngrok tunnel to bridge local development with enterprise Azure resources.

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
    Whatsminer --"Raw Firmware Data (JSON)"--> Regex
    Antminer --"Raw Firmware Data (String)"--> Regex
    Regex --"Structured Telemetry"--> SafetyLoop
    SafetyLoop --"Kill Command (>85°C)"--> TCPSocket

    %% 3. Web & Cloud Data
    WebApp --"Entity Framework Core"--> Ngrok
    Ngrok --"Bypasses Firewall (Error 40)"--> AzureSQL

    %% --- APPLY STYLES ---
    class Whatsminer,Antminer hardware;
    class AzureSQL data;
