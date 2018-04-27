import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class AboutComponent extends Vue {
    imageUrl : string;
    
    data(){
        return {
            imageUrl: require("./resources/images/aboutheader.png")
        }
    }
}
