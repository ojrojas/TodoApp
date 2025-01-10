import * as React from "react";
import type { InferGetServerSidePropsType } from "next";
import { getServerSideProps } from "./getcsrfToken";
import { Box, Button, Container, TextField } from "@mui/material";

export default function SignIn({
  csrfToken,
}: InferGetServerSidePropsType<typeof getServerSideProps>) {
  return (
    <Container sx={{ width: "100vw", height: '100vh', display:'flex', justifyContent:'center', alignItems:'center' }}>
      <Box
        component="form"
        sx={{ "& .MuiTextField-root": { m: 1, width: 400 } , 
        width:500, 
        height: 700,
        border: '5px solid azure', 
        display:'flex', 
        flexDirection:'column',
        justifyContent:'center', 
        alignItems:'center'}}
        noValidate
        autoComplete="off"
      >
        <h3>Todo APP</h3>
        <label>Login</label>
        <div>
          <input name="csrfToken" type="hidden" defaultValue={csrfToken} />
          <TextField
            variant="outlined"
            id="username"
            label="UserName"
            defaultValue=""
            type="email"
            required
          />
        </div>
        <div>
          <TextField
            variant="outlined"
            id="password"
            label="Password"
            type="password"
            defaultValue=""
            required
          />
        </div>
        <div>
          <Button type="submit">Login</Button>
        </div>
      </Box>
    </Container>
  );
}
