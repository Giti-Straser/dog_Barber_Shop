import React, { useState } from 'react';
import './Login.css';
import db from '../connectToServer'
import { useNavigate } from 'react-router-dom';






function Login() {
  const [name, setName] = useState('');
  const [pass, setPass] = useState('');
  const navigate = useNavigate();
  function login(userName, password) {

    db.getCustomerByUserNameAndPassword(userName, password).then(data => {
      if (data) {
        db.c.currentCustomer = data;
        navigate('/queue');
      }
    })
  
  }
  function signin() {
    navigate('/signIn');
  }

  return (
    <div className='divv'>

      <h3 className='line'>user name</h3>
      <input className='in' value={name} onChange={e => setName(e.target.value)} />
      <h3 className='line'>password</h3>
      <input className='in in5' type={'password'} value={pass} onChange={e => setPass(e.target.value)} />
      <button className='btnLogin' onClick={() => login(name, pass)}>login</button>
      <button className='btnSignin' onClick={signin}>new user</button>
    </div>
  )
}
export default Login;