import React, { Component } from 'react';
import * as axios from 'axios';
import { API_LOGIN } from '../common/constants';

export class Login extends Component {
    email;
    password;

    constructor(props) {
        super(props);
        this.state = { email: '', password: '' };
    }

    tryLogin() {
        const data = JSON.stringify({
            email: '4teste00@mail.com',
            password: 'HE@E20qwe123'
        });
        axios.post('api/Account/Login', data, { headers: { 'Content-Type': 'application/json' } })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <form>
                    <input placeholder="E-mail" value={this.email} />
                    <br />
                    <input placeholder="Password" type="password" value={this.password} />
                    <br />
                    <button onClick={this.tryLogin} type="button">Login</button>
                </form>
            </div>
        );
    }
}
