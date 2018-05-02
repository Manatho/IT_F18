import './../../model/Subscriber'
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
 
@Component
export default class AdminComponent extends Vue {
    subscribers: Subscriber[];
    newEmail : string;
 
    data() {
        return {
            newEmail: "",
            subscribers: []
        };
    }

    addItem(event : Event){
        if(event) event.preventDefault();
         this.$validator.validateAll().then((isValid) => {
            if(isValid){
                fetch('/api/subscribers', {
                    method: 'post',
                    body: JSON.stringify(<Subscriber>{email: this.newEmail, id: 0}),
                    headers: new Headers({
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                    })
                })
                .then(response => response.json() as Promise<Subscriber>)
            }
            
         });
         
        

        
    }
}