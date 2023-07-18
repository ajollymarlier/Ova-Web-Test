import logo from './logo.svg';
import './App.css';
import { TextField, Button, Box, Grid } from '@mui/material';
import React, {useState} from 'react';

function App() {
  const [signUpUsername, setSignUpUsername] = useState('');
  const [signUpFirstName, setSignUpFirstName] = useState('');
  const [signUpLastName, setSignUpLastName] = useState('');
  const [signUpEmail, setSignUpEmail] = useState('');
  const [signUpPassword, setSignUpPassword] = useState('');
  const [signUpConfirmPassword, setSignUpConfirmPassword] = useState('');
  const [searchUsername, setSearchUsername] = useState('');
  const [deleteUsername, setDeleteUsername] = useState('');

  return (
    <div className="App">
      <header className="App-header">
        <Box 
          id="userSignUpForm"
          boxShadow={6}>
          <TextField id="signUpUsernameField" label="Username" variant="filled" 
            onChange={(event) => {
              setSignUpUsername(event.target.value)}} />

          <TextField id="firstNameField" label="First Name" variant="filled" 
            onChange={(event) => {
              setSignUpFirstName(event.target.value)}} />

          <TextField id="lastNameField" label="Last Name" variant="filled" 
            onChange={(event) => {
              setSignUpLastName(event.target.value)}} />
          
          <TextField id="emailField" label="Email" variant="filled" 
            onChange={(event) => {
              setSignUpEmail(event.target.value)}} />

          <TextField id="passwordField" label="Password" variant="filled" 
            onChange={(event) => {
              setSignUpPassword(event.target.value)}} />

          <TextField id="confirmPasswordField" label="Confirm Password" variant="filled" 
            onChange={(event) => {
              setSignUpConfirmPassword(event.target.value)}} />

          <Button variant="contained" onClick={async () => {
            const signUpObject = {
              "userName": signUpUsername,
              "firstName": signUpFirstName,
              "lastName": signUpLastName,
              "email": signUpEmail,
              "password": signUpPassword,
              "confirmPassword": signUpConfirmPassword
            }

            console.log(signUpObject)

            const response = await fetch('https://localhost:5001/User/signup', {
              method: 'POST',
              mode: 'cors',
              headers: {'content-type': 'application/json'},
              dataType: "json",
              body: signUpObject
            })

            const resBody = await response.json()
            console.log(resBody)
          }}>

            Sign Up
          </Button>
        </Box>

        <Box 
          id="userSearchForm"
          boxShadow={6}>
          <TextField 
            id="searchUsernameField" 
            label="Username" 
            onChange={(event) => {
                        setSearchUsername(event.target.value)}} 
            variant="filled" 
          />

          <Button variant="contained" onClick={async () => {
            const response = await fetch('https://localhost:5001/User/profile?userName=' + searchUsername, {
              method: 'GET',
              mode: 'cors',
              headers: {'content-type': 'application/json'},
              dataType: "json"
            })

            const resBody = await response.json()
            console.log(resBody)

            if (resBody.userName != undefined){
              alert(resBody.userName)
            } 
            else {
              alert("No User Found!")
            }
          }}>

            Find User
          </Button>
        </Box>

        <Box 
          id="userSignUpForm"
          boxShadow={6}>
          <TextField id="deleteUsernameField" label="Username" variant="filled" 
            onChange={(event) => {
              setDeleteUsername(event.target.value)}} />

          <Button variant="contained" onClick={async () => {
            const response = await fetch('https://localhost:5001/User/profile/delete?userName=' + deleteUsername, {
              method: 'DELETE',
              mode: 'cors',
              headers: {'content-type': 'application/json'},
              dataType: "json"
            })

            if (response.status != 400){
              alert("User Deleted!")
            }
            else {
              alert("User Not Found!")
            }
          }}>

            Delete User
          </Button>
        </Box>
        

      </header>
    </div>
  );
}

export default App;
