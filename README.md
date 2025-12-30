# Alfano Tech Portfolio & Miner Control Center (MCC)

## Overview
This repository contains the full source code for my production-grade technical portfolio and the **Miner Control Center (MCC)**, a custom C# application designed for high-frequency ASIC hardware management.

## 🚀 Projects Included

### 1. Full-Stack Cloud Portfolio
A .NET 8 web application designed to showcase engineering projects with a focus on cloud automation.
* **Tech Stack:** ASP.NET Core 8, Entity Framework Core, SQL Server, Bootstrap 5.
* **Infrastructure:** Azure App Services & Azure SQL provisioned via **Terraform**.
* **Engineering Pivot:** During development, I encountered a persistent Azure SQL "Error 40" (Network Path Not Found). Instead of stalling, I engineered a secure local tunnel using **Ngrok** to bypass the firewall and continue development against the live environment.

### 2. Miner Control Center (MCC)
A desktop telemetry system built to manage mixed-fleet ASIC miners (Whatsminer/Antminer) without relying on slow web interfaces.
* **Core Logic:** Bypassed standard HTTP protocols by engineering raw **TCP/IP socket connections** (Port 4028) to inject JSON-RPC payloads directly into miner firmware.
* **Data Parsing:** Developed custom **Regex** engines to normalize non-standard text returns from different hardware manufacturers into structured C# objects.
* **Safety Automation:** Implemented background monitoring loops that trigger auto-shutdown commands if hashboard temperatures exceed 85°C.

## 🛠️ Setup & Usage
This project is currently configured for local development using a secure tunnel.
* **Prerequisites:** .NET 8 SDK, Visual Studio 2022.
* **Database:** Configured for SQLite (Local) or Azure SQL (Cloud) via connection string toggles.

---
*Built by Antonio Alfano - Aspiring Cloud & Systems Engineer*
