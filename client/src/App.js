import logo from './logo.svg';
import './App.css';
import { TextField, Button, Box, Grid } from '@mui/material';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Box 
          id="userSignUpForm"
          boxShadow={6}>
          <TextField id="signUpUsernameField" label="Username" variant="filled" />
          <TextField id="firstNameField" label="First Name" variant="filled" />
          <TextField id="lastNameField" label="Last Name" variant="filled" />
          <TextField id="passwordField" label="Password" variant="filled" />
          <TextField id="confirmPasswordField" label="Confirm Password" variant="filled" />

          <Button variant="contained" onClick={async () => {
            // const response = await fetch(`/User/profile?userName=` + "arunjm", {
            //   method: 'GET',
            //   headers: {'content-type': 'application/json'}
            // })

            const response = await fetch('https://localhost:5001/User/profile?userName=arunjm', {
              method: 'GET',
              mode: 'cors',
              headers: {'content-type': 'application/json'},
              dataType: "json"
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
          <TextField id="searchUsernameField" label="Username" variant="filled" />

          <Button variant="contained" onClick={async () => {
            const response = await fetch(`http://localhost:5001/User/profile`)
            console.log(await response.json())
          }}>

            Find User
          </Button>
        </Box>

        <Box 
          id="userSignUpForm"
          boxShadow={6}>
          <TextField id="deleteUsernameField" label="Username" variant="filled" />

          <Button variant="contained" onClick={async () => {
            const response = await fetch(`http://localhost:5001/User/profile`)
            console.log(await response.json())
          }}>

            Delete User
          </Button>
        </Box>
        

      </header>
    </div>
  );
}

export default App;
