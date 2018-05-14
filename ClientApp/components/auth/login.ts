import './../../model/LoginData'
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
 
@Component
export default class LoginComponent extends Vue {
    username: string;
    password: string;
    error: boolean;

    data(){
        return {
            username: "",
            password: "",
            error: false
        };
    }

    login(event : Event){
        if(event) event.preventDefault();
        
        fetch('/api/authentication/login', {
            method: 'post',
                    body: JSON.stringify(<LoginData>{username: this.username, password: this.password}),
                    headers: new Headers({
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                    })
        })
        .then(response => {
            if(!response.ok){
                this.error = true;
                
            } else {
                this.$store.dispatch("setAdmin", true);
                this.$router.push("/admin")
            }
        });
        
    }
}