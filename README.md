Run project. Browser opens with UI.

Example query to demonstrate error for invalid input:

```graphql
query MyQuery {
  user(id: "invalid") {
    id
    emailAddress
    name
  }
}
```

