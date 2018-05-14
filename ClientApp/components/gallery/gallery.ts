
import './../../model/GalleryEntry'
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class GalleryComponent extends Vue {
    entries: GalleryEntry[];
    imageUrl: string;
    lightboxImage: string;
    showLightBox: boolean;

    data() {
        return {
            entries: [],
            imageUrl: require("./resources/images/Missing.png"),
            lightboxImage: require("./resources/images/Missing.png"),
            showLightBox: false
        };
    }

    mounted() {
        fetch('/api/GalleryEntries')
            .then(response => response.json() as Promise<GalleryEntry[]>)
            .then(data => {
                this.entries = data;
            });
    }

    setLightbox(show: boolean, event: GalleryEntry) {

        if (show) {
            console.log(event);

            this.lightboxImage = event.imagePath;
        }

        this.showLightBox = show;



    }
}