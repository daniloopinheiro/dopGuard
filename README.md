# dopGuard

[![dopGuard Net - CI](https://github.com/daniloopinheiro/dopGuard/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/daniloopinheiro/dopGuard/actions/workflows/dotnet.yml)

**Plataforma modular de observabilidade** para aplicações .NET com integração plugável a ferramentas como **Datadog**, **Elastic Stack**, **Grafana/Prometheus**, **Azure Monitor**, entre outras.

O `dopGuard` fornece uma base sólida para **observabilidade distribuída**, com arquitetura robusta, extensível e pronta para ambientes empresariais modernos.

---

## 📚 Índice

1. [Visão Geral](#visão-geral)
2. [Instalação](#instalação)
3. [Como Usar](#como-usar)
4. [Configuração](#configuração)
5. [Contribuições](#contribuições)
6. [Licença](#licença)
7. [Contato](#contato)

---

## 🔭 Visão Geral

O `dopGuard` implementa uma arquitetura de referência para observabilidade de aplicações .NET, aplicando conceitos como:

* 🔌 *OpenTelemetry como padrão universal*
* 🧩 Integração com múltiplos backends: **Datadog**, **Elastic APM**, **Grafana + Prometheus**, **Azure Application Insights**
* 📈 Métricas, Logs, Traces e Health Checks com rastreabilidade distribuída
* 🔁 Suporte a múltiplos protocolos: OTLP HTTP/gRPC, Logstash, Prometheus PushGateway
* ♻️ Modular e extensível para uso com Clean Architecture e DDD

---

## ⚙️ Instalação

### Pré-requisitos

* [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
* [Docker](https://www.docker.com/)
* [Docker Compose](https://docs.docker.com/compose/)
* [Git](https://git-scm.com/)

### Clonando o projeto

```bash
git clone https://github.com/daniloopinheiro/dopGuard.git
cd dopGuard
```

### Subindo infraestrutura de observabilidade (opcional)

```bash
docker-compose up -d
```

---

## 🚀 Como Usar

### Executando localmente

```bash
cd dopGuard.Api
dotnet run
```

A API estará disponível em: `https://localhost:5001`
Documentação via Swagger: `https://localhost:5001/swagger`

### Rodando testes

```bash
dotnet test
```

---

## ⚙️ Configuração

### OpenTelemetry com múltiplos backends

No `appsettings.json`:

```json
"Otel": {
  "Endpoint": "http://localhost:4318/v1/traces",
  "EnableDatadog": true,
  "EnableElastic": true,
  "EnablePrometheus": true,
  "EnableAzureMonitor": false
}
```

### Variáveis de ambiente

Configure no `.env` ou `docker-compose.override.yml`:

```env
DATADOG_API_KEY=your-datadog-api-key
ELASTIC_APM_SERVER_URL=http://localhost:8200
PROMETHEUS_PUSHGATEWAY=http://localhost:9091
APPLICATIONINSIGHTS_CONNECTION_STRING=InstrumentationKey=...
```

### Docker Compose

```yaml
datadog:
  image: gcr.io/datadoghq/agent:latest
  environment:
    - DD_API_KEY=${DATADOG_API_KEY}
    - DD_OTLP_CONFIG_RECEIVER_PROTOCOLS_HTTP_ENABLED=true
    - DD_LOGS_ENABLED=true
  ports:
    - "4318:4318"
    - "8126:8126"
```

---

## 🧱 Estrutura do Projeto

```bash
dopGuard/
│
├── dopGuard.Api/              # API com rastreabilidade e logs
├── dopGuard.Application/      # Casos de uso
├── dopGuard.Domain/           # Regras de negócio
├── dopGuard.Infrastructure/   # Persistência e mensageria
├── dopGuard.Observability/    # Integrações com Datadog, ELK, Prometheus, etc
├── dopGuard.BuildingBlocks/   # Extensions de OpenTelemetry, Logging e Metrics
├── dopGuard.Tests/            # Testes automatizados
├── docker-compose.yml
└── README.md
```

---

## 🤝 Contribuições

Contribuições são bem-vindas!

### Como contribuir

1. Faça um fork do projeto
2. Crie uma branch: `git checkout -b feature/nova-funcionalidade`
3. Commit: `git commit -m 'feat: nova funcionalidade'`
4. Push: `git push origin feature/nova-funcionalidade`
5. Abra um Pull Request 🚀

---

## 📄 Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).

---

## 👋 Contato

Tem dúvidas ou sugestões? Fale comigo:

* **Email Pessoal**: [daniloopro@gmail.com](mailto:daniloopro@gmail.com)
* **Empresarial**: [devsfree@devsfree.com.br](mailto:devsfree@devsfree.com.br)
* **Consultoria**: [contato@dopme.io](mailto:contato@dopme.io)
* **LinkedIn**: [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro)

---

<p align="center">Feito com ❤️ por <strong>Danilo O. Pinheiro</strong><br/> <a href="https://devsfree.com.br" target="_blank">DevsFree</a> • <a href="https://dopme.io" target="_blank">dopme.io</a></p>

