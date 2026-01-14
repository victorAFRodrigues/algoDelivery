# 🚚 algoDelivery — Microservices Platform

Plataforma de microserviços em .NET, construída com foco em DDD (Domain-Driven Design), Clean Architecture e arquitetura orientada a eventos, utilizando Docker, PostgreSQL e Kafka para comunicação assíncrona entre serviços.

Este repositório segue o conceito de monorepo, onde cada microserviço é totalmente isolado, com sua própria solução (.sln), regras de negócio e ciclo de vida.

## 🧠 Visão Geral da Arquitetura

- Arquitetura de microserviços
- Clean Architecture por serviço
- DDD com Bounded Contexts bem definidos
- Comunicação assíncrona (event-driven)
- Infraestrutura local via Docker Compose
- Preparado para CI/CD e Kubernetes

## 📂 Estrutura do Repositório
```bash
algoDelivery
├── Docs
│   ├── tree.txt
│   └── README.md
├── docker-compose.yml
└── microservices
    ├── CourierManagement
    │   └── CourierManagement.sln
    └── DeliveryTracking
        └── DeliveryTracking.sln

```

## 📌 Descrição dos diretórios
| Diretório            |                   Descrição                   |
|----------------------|:---------------------------------------------:|
| `Docs/`              | Documentação técnica e decisões arquiteturais |
| `docker-compose.yml` | Infraestrutura compartilhada (DB, Kafka, etc.) |
| `microservices/`     |          Microserviços independentes          |
| `CourierManagement/` |   Bounded Context de gestão de entregadores   |
| `DeliveryTracking/`  |  Bounded Context de rastreamento de entregas  |
	

## 🧩 Microserviços
### 🚴 CourierManagement

Responsável pelo ciclo de vida do entregador:

- Cadastro

- Ativação / desativação

- Disponibilidade

- Associação a entregas

📦 Banco de dados isolado

### 📦 DeliveryTracking

Responsável pelo rastreamento e status das entregas:

- Criação de entregas

- Atualização de status

- Histórico de eventos

- Consulta de tracking

📦 Banco de dados isolado

## 🏗️ Estrutura Interna de um Microserviço

Cada pasta dentro de microservices/* contém uma solution própria:

```bash
CourierManagement
├── CourierManagement.Api
├── CourierManagement.Application
├── CourierManagement.Domain
└── CourierManagement.Infrastructure
```

## 🧱 Camadas (Clean Architecture)

- Domain
  - Entidades
  - Aggregates
  - Value Objects
  - Domain Events

- Application
  - Casos de uso
  - DTOs
  - Interfaces

- Infrastructure
  - EF Core
  - Kafka Producers / Consumers
  - Repositórios

- API
  - Endpoints REST
  - Middleware
  - DI / Configurações

## 🐳 Infraestrutura Local (Docker)

A infraestrutura compartilhada roda via Docker Compose, localizada na raiz do repositório.

#### Serviços disponíveis:
  - PostgreSQL
  - PgAdmin
  - (Kafka — planejado)

### ▶️ Subir a infraestrutura
```bash
docker compose up -d
```

### 🔎 Acessos locais

- PostgreSQL: localhost:5432
  - PgAdmin: http://localhost:8083
  - Email: dba@algadelivery.com
  - Senha: algadelivery

### 📨 Comunicação entre Serviços (Kafka)

Os microserviços se comunicam via eventos de domínio, publicados no Kafka.

#### Padrões adotados:
- Event-driven architecture
- Consumer Groups
- Mensagens imutáveis
- Idempotência
- At-least-once delivery
- Dead Letter Topics (DLT)

📌 Nenhum microserviço acessa o banco de outro.

### 🔐 Configuração & Secrets
- `appsettings.json` → versionado
- `appsettings.Development.json` → não versionado
- Variáveis de ambiente → Docker / Kubernetes

### 🧪 Testes
- Testes unitários no Domain
- Testes de Application (use cases)
- Infra mockada para isolamento

### 🚀 Tecnologias Utilizadas
- .NET 10
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Kafka
- Docker / Docker Compose
- Clean Architecture
- Domain-Driven Design (DDD)

### ⚠️ Princípios Importantes
- Microserviços não compartilham banco
- Cada .sln é independente
- Deploy independente por serviço
- Comunicação síncrona evitada
- Bounded Contexts bem definidos

### 🧭 Próximos Passos
- Adicionar Kafka ao docker-compose
- Versionar eventos
- Implementar Outbox Pattern
- Observabilidade (OpenTelemetry)
- CI/CD
- Kubernetes

### 📘 Documentação
Este projeto foi criado com foco em boas práticas de arquitetura, aprendizado contínuo e aplicação real de conceitos avançados em .NET e microserviços.
Toda documentação adicional pode ser encontrada em:

```
docs/
├── README.md
├── CourierManagement/
└── DeliveryTracking/
```
