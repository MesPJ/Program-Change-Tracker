**Program Change Tracker**

A lightweight ASP.NET Core Razor Pages application built to model a change request workflow commonly found in internal enterprise systems.

The project focuses on clean architecture, request lifecycles, and service-based design, rather than UI complexity.

**Purpose**

This application was built as a hands-on refresher and skills validation project to demonstrate:

How server-side web applications handle GET vs POST requests

How model binding works in ASP.NET Core

How to structure logic using Page Models + Services

How to manage workflow state using enums

How to implement CRUD operations, including soft delete

How enterprise systems track changes using audit fields

****Core Features**
Change Request Lifecycle**

Create change requests with Title and Description

Track status using a controlled workflow:

Open

In Review

Closed

Update status via dropdown (auto-submit on change)

Edit existing change requests inline

Soft delete change requests (records are hidden, not removed)

Validation & UX

Required field validation for Title

Clear user feedback when validation fails

Post–Redirect–Get (PRG) pattern to prevent duplicate submissions

Architecture Overview
Razor Pages + Page Models

Each page has:

A .cshtml file (UI / rendering)

A .cshtml.cs Page Model (request handling)

Page Models handle:

GET requests (OnGet)

POST requests (OnPost, OnPostUpdateStatus, etc.)

UI never contains business logic

Service Layer

All business behavior lives in ChangeRequestService

Page Models coordinate, Services execute

This separation enables:

cleaner code

easier testing

future replacement of in-memory storage with a database

Data Model

ChangeRequest represents persistent business data

Uses:

Id for identity

ChangeStatus enum for workflow state

CreatedAt / UpdatedAt for auditing

IsDeleted for soft delete behavior

Soft Delete Pattern

Instead of removing records, change requests are marked as deleted:

IsDeleted = true


Deleted items:

remain in memory

are excluded from normal queries

preserve auditability and traceability

This mirrors how real enterprise systems handle deletion.

Technical Concepts Demonstrated

ASP.NET Core Razor Pages

Dependency Injection

Model Binding with [BindProperty]

Enum-based state management

Service-based architecture

GET vs POST request lifecycle

PRG (Post–Redirect–Get) pattern

Validation and user feedback

Soft delete design pattern

**Technology Stack**

C#

.NET / ASP.NET Core

Razor Pages

In-memory data storage (service-based, easily replaceable)

Future Improvements (Not Implemented by Design)

These were intentionally left out to keep the project focused:

Authentication / authorization

Database persistence (EF Core)

Role-based workflows

Frontend JavaScript frameworks

Advanced UI styling

The goal of this project is architecture clarity, not feature bloat.

**Summary**

This project demonstrates how to design and reason about a small but realistic enterprise-style web application, with emphasis on:

correctness

separation of concerns

maintainability
